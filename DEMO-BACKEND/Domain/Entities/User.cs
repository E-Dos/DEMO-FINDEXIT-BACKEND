using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Username { get; set; } = "";
        [StringLength(500)]
        [DataType(DataType.Password)]
        [JsonIgnore]
        public string Password { get; set; }
        [MaxLength(200)]
        public string FIO { get; set; }
        [MaxLength(200)]
        public string Position { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }

    
    }
}
