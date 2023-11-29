using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TEMPLATE_ELDOS_BACKEND.App;
using TEMPLATE_ELDOS_BACKEND.Domain.Entities;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Data;
using TEMPLATE_ELDOS_BACKEND.Models;
using X.PagedList;

namespace TEMPLATE_ELDOS_BACKEND.Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<UsersController> _logger;
        private const int PAGE_SIZE = 15;

        public UsersController(AppDbContext db, ILogger<UsersController> logger, IHttpContextAccessor _httpContextAccessor)
        {
            _db = db;
            _logger = logger;
            httpContextAccessor = _httpContextAccessor;
        }

        [HttpGet("GetRole")]
        public IActionResult GetRole()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null)
            {
                return BadRequest("User claims not found");
            }

            var roleClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (roleClaim == null)
            {
                return BadRequest("User role claim not found");
            }

            var userRole = roleClaim.Value;

            var result = new RoleModel
            {
                name = userRole,
                permissions = null
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _db.Users.Where(x => x.Id == id).Select(user => new
            {
                id = user.Id,
                username = user.Username,
                roleId = user.RoleId,
            });

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpGet("RoleList")]
        public IActionResult RoleList()
        {
            var roles = _db.SecurityRoles.ToList();
            return Ok(roles);
        }

        [HttpPost("List")]
        public IActionResult List(PageParam param)
        {
            var data = _db.Users
                .ToList()
            .Select(user => new
            {
                id = user.Id,
                username = user.Username,
                firstName = user.FirstName,
                lastName = user.LastName,
                birthDate = user.BirthDate,

            });

            var list = data.ToPagedList(param.pageNumber, PAGE_SIZE);
            var response = new ApiResponse()
            {
                result = new
                {
                    list.TotalItemCount,
                    list.PageNumber,
                    list.PageCount,
                    list.PageSize,
                    list.HasPreviousPage,
                    list.HasNextPage,
                    list.IsFirstPage,
                    list.IsLastPage,
                    list.FirstItemOnPage,
                    list.LastItemOnPage,

                    Items = list
                }
            };

            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Save([FromBody] UserDTO item)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.Id == item.Id);
                if (user == null)
                {
                    user = new User
                    {
                        Created = DateTime.Now
                    };
                    _db.Users.Add(user);
                }

                user.Username = item.Username;
                if (item.Password != null)
                {
                    user.Password = UserHelper.HashPassword(item.Password);
                }
                user.RoleId = item.RoleId;
                user.Updated = DateTime.Now;

                await _db.SaveChangesAsync();

                return Ok(new ApiResponse
                {
                    result = user
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR USER_UPD_OR_CREATE: {ex}");
                return BadRequest("An error occurred while saving user");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            _db.Remove(user);

            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation($"USER: {id} is deleted");
                return Ok(new ApiResponse
                {
                    result = "success"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting USER: {ex.Message}");
                return BadRequest("An error occurred while deleting user");
            }
        }
    }
}
