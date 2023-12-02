using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CompletionPercent { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
