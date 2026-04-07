using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    [Flags]
    public enum PermissionsFlags
    { 
        None = 0,
        Read = 1 << 0,
        Create = 1 << 1,
        Updete = 1 << 2,
        Delete = 1 << 3,
    }
    public class Role
    {
        public Guid RoleId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
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
