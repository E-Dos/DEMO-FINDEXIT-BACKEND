using App;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
namespace Controllers
{
    [Route("api/tasks")]
    [Authorize]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<TasksController> _logger;

        public TasksController(AppDbContext db, ILogger<TasksController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _db.Tasks.Include(tsk => tsk.User).Select(task => new Tasks
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                UserId = task.Id,
                User = task.User,
                CompletionPercent = task.CompletionPercent,
            }).ToListAsync();
            return Ok(tasks);
        }
        [HttpGet("overdueTasks")]
        public async Task<IActionResult> OverdueTasks()
        {
            var tasks = await _db.Tasks.Include(tsk => tsk.User).Where(x => x.EndDate < DateTime.Now && x.CompletionPercent < 100).Select(task => new Tasks
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                UserId = task.Id,
                User =  new User{ FIO = task.User.FIO },
                CompletionPercent = task.CompletionPercent,
            }).ToListAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tasks = await _db.Tasks.Where(m => m.UserId == id).ToListAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDTO item)
        {
            try
            {
                var task = new Tasks()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    StartDate = item.StartDate.AddHours(6),
                    EndDate = item.EndDate.AddHours(6),
                    CompletionPercent = new Random().Next(0, 100),
                    UserId = item.UserId
                };

                _db.Add(task);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating TASK: {ex}");
                return BadRequest("Произошла ошибка при создании задачи");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TaskDTO item)
        {
            // проверка на null тут ненужно, так как 
            try
            {
                var task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == item.Id);

                task.Name = item.Name;
                task.Description = item.Description;
                task.StartDate = item.StartDate.AddHours(6);
                task.EndDate = item.EndDate.AddHours(6);
                task.CompletionPercent = new Random().Next(item.CompletionPercent ?? 0, 100);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating TASK: {ex}");
                return BadRequest("Произошла ошибка при обновлении задачи");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _db.Tasks.FirstOrDefault(x => x.Id == id);
            _db.Remove(user);

            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation($"TASK: ID={id} is deleted");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting TASK: ID={id} {ex.Message}");
                return BadRequest("Произошла ошибка при удалении задачи");
            }
        }
    }
}
