using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TEMPLATE_ELDOS_BACKEND.Models;

namespace TEMPLATE_ELDOS_BACKEND.Domain.Entities;

public class SecurityRole : BaseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<SecurityRoleResource> SecurityRoleResources { get; } = new List<SecurityRoleResource>();
}
