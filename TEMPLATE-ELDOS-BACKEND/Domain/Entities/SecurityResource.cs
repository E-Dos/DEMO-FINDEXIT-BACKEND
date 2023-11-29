using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TEMPLATE_ELDOS_BACKEND.Models;

namespace TEMPLATE_ELDOS_BACKEND.Domain.Entities;

public class SecurityResource : BaseModel
{
    public int Id { get; set; }

    [StringLength(500)]
    public string Name { get; set; } = null!;
    public virtual ICollection<SecurityRoleResource> SecurityRoleResources { get; } = new List<SecurityRoleResource>();
}
