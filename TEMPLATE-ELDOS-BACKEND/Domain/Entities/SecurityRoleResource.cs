using System;
using System.Collections.Generic;
using TEMPLATE_ELDOS_BACKEND.Models;

namespace TEMPLATE_ELDOS_BACKEND.Domain.Entities;

public class SecurityRoleResource : BaseModel
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public int ResourceId { get; set; }

    public bool View { get; set; }

    public bool Edit { get; set; }

    public bool Delete { get; set; }

    public virtual SecurityResource Resource { get; set; } = new SecurityResource();

    public virtual SecurityRole Role { get; set; } = new SecurityRole();
}
