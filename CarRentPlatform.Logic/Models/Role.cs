using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum RoleNameId
    { 
        None = 0,
        User = 1,
        Admin = 2,
        Moderator = 3,
        Operator = 4,
        CarManager = 5,
        UserManager = 6,
    }

    [Flags]
    public enum PermissionsFlags
    { 
        None = 0,
        Create = 1 << 0,
        Read = 1 << 1,
        Updete = 1 << 2,
        Delete = 1 << 3
    }

    public class Role
    {
        public RoleNameId RoleNameId { get; set; }
        public PermissionsFlags ModelPermissions { get; set; }
        public PermissionsFlags CarsPermissions { get; set; }
        public PermissionsFlags UserPermissions { get; set; }
        public PermissionsFlags SelfPermissions { get; set; }
        public PermissionsFlags RentalPeriodPermissions { get; set; }
        public PermissionsFlags RolePermissions { get; set; }

        public Role()
        {
        
        }
    }
}
