using App;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using X.PagedList;


namespace Controllers
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
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, auth.Username),
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

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Authenticate ERROR: {ex.Message}");
                return BadRequest("Произошла ошибка во время аутентификации");
            }
        }
    }
}
