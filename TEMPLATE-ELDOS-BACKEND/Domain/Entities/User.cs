using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TEMPLATE_ELDOS_BACKEND.Models;

namespace TEMPLATE_ELDOS_BACKEND.Domain.Entities
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Username { get; set; } = "";
        [StringLength(500)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string FirstName { get; set; } = "";
        [MaxLength(200)]
        public string LastName { get; set; } = "";
        [MaxLength(200)]
        public string SurName { get; set; } = "";
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [MaxLength(12)]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public bool? IsPhoneConfirmed { get; set; }
        [JsonPropertyName("roleId")]
        public int? RoleId { get; set; }
        [JsonIgnore]
        public virtual SecurityRole? Role { get; set; }
        [NotMapped]
        public string? access_token { get; set; }
        public string? ConnectionIdHub { get; set; }
    }
}
