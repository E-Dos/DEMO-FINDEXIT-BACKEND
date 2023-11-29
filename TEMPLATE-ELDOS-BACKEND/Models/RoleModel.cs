using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace TEMPLATE_ELDOS_BACKEND.Models
{
    public class RoleModel
    {
        public string? name { get; set; }
        public List<UserPermissionModel>? permissions { get; set; }
    }

    public class UserPermissionModel
    {
        public string? Type { get; set; }
        public string? Resource { get; set; }
    }
}