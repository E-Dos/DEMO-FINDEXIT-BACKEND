using App;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
namespace Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<UsersController> _logger;

        public UsersController(AppDbContext db, ILogger<UsersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _db.Users
                .Include(user => user.Tasks)
                .Select(user => new User
                {
                    Id = user.Id,
                    Username = user.Username,
                    FIO = user.FIO,
                    Position = user.Position,
                    Tasks = user.Tasks
                }).ToListAsync();

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO item)
        {
            try
            {
                var user = new User()
                {
                    Id = item.Id,
                    Username = item.Username,
                    FIO = item.FIO,
                    Position = item.Position,
                    Password = UserHelper.HashPassword(item.Password)
                };

                _db.Add(user);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating USER: {ex}");
                return BadRequest("Произошла ошибка при создании пользователя");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDTO item)
        {
            try
            {
                var user = await _db.Users.FindAsync(item.Id);
                if (user == null)
                    return NotFound();

                user.Username = item.Username;
                user.FIO = item.FIO;
                user.Position = item.Position;

                if (item.Password != null)
                {
                    user.Password = UserHelper.HashPassword(item.Password);
                }
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating USER: {ex}");
                return BadRequest("Произошла ошибка при обновлении пользователя");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _db.Remove(user);

            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation($"USER: ID={id} is deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting USER: ID={id} {ex.Message}");
                return BadRequest("Произошла ошибка при удалении пользователя");
            }
        }
    }
}
