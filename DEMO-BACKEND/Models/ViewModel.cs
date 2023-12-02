using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; } = null!;
        public string? FIO { get; set; } = null!;
        public string? Position { get; set; } = null!;
    }
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
    public class TaskDTO
    {
        public int Id { get; set; }
        public int? CompletionPercent { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
