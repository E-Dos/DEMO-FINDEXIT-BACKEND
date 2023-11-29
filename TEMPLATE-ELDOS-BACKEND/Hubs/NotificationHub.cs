using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using TEMPLATE_ELDOS_BACKEND.App;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Data;

namespace TEMPLATE_ELDOS_BACKEND.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _db;
        public NotificationHub(AppDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }
        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var userId = _httpContextAccessor.HttpContext.User.GetId().ToString();
            var user = _db.Users.FirstOrDefault(x => x.Id == int.Parse(userId));

            // Удалить существующий ConnectionId, если он есть
            if (!string.IsNullOrEmpty(user.ConnectionIdHub))
            {
                user.ConnectionIdHub = null;
                _db.Update(user);
                await _db.SaveChangesAsync();
            }

            // Установить новый ConnectionId
            user.ConnectionIdHub = connectionId;
            _db.Update(user);
            await _db.SaveChangesAsync();

            await base.OnConnectedAsync();
        }
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }
    }
}
