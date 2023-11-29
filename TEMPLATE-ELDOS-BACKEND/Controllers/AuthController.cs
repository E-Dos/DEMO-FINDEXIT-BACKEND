using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TEMPLATE_ELDOS_BACKEND.App;
using TEMPLATE_ELDOS_BACKEND.Domain.Entities;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Data;
using TEMPLATE_ELDOS_BACKEND.Models;
using X.PagedList;


namespace TEMPLATE_ELDOS_BACKEND.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext db, ILogger<AuthController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                // Проверка, существует ли пользователь с таким email
                var existingUser = _db.Users.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Пользователь с таким email уже существует." });
                }

                // Проверка совпадения паролей
                if (model.Password != model.ConfirmPassword)
                {
                    return BadRequest(new { message = "Пароль и подтверждение пароля не совпадают." });
                }

                // Создание нового пользователя
                var newUser = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = UserHelper.HashPassword(model.Password),
                    // Добавьте другие поля регистрации по вашему усмотрению
                };

                // Добавление пользователя в базу данных
                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();
                _logger.LogInformation($"{DateTime.Now} --- Пользователь с Логином {model.Username} зарегистрировался");
                return Ok(new { message = "Регистрация прошла успешно." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} --- ERROR USER_REGISTER: {ex}");
                return BadRequest("Произошла ошибка при регистрации пользователя.");
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            return Ok(new { message = "Вы успешно вышли из системы." });
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var auth = _db.Users.SingleOrDefault(q => q.Username == model.Username);

                if (auth != null && UserHelper.VerifyPassword(model.Password, auth.Password))
                {
                    var role = _db.SecurityRoles.FirstOrDefault(q => q.Id == auth.RoleId);
                    string roleName = role != null ? role.Name : "guest";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, auth.Username),
                        new Claim(ClaimTypes.Role, roleName),
                        new Claim("UserId", auth.Id.ToString())
                    };

                    var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(200)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );

                    string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

                    _logger.LogInformation($"{DateTime.Now} --- Пользователь с Логином {model.Username} авторизовался");

                    return Ok(new
                    {
                        id = auth.Id,
                        name = auth.Username,
                        token = accessToken
                    });
                }

                return Unauthorized("Authentication failed");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Authenticate ERROR: {ex.Message}");
                return BadRequest("An error occurred during authentication");
            }
        }
    }
}
