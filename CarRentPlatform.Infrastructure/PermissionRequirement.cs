using System;
using System.Collections.Generic;
using System.Text;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarRentPlatform.Infrastructure
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionsFlags ModelPermissions { get; set; }
        public PermissionsFlags CarsPermissions { get; set; }
        public PermissionsFlags UserPermissions { get; set; }
        public PermissionsFlags SelfPermissions { get; set; }
        public PermissionsFlags RentalPeriodPermissions { get; set; }
        public PermissionsFlags RolePermissions { get; set; }
        public PermissionRequirement(PermissionsFlags modelPermissions, PermissionsFlags carsPermissions, PermissionsFlags userPermissions, PermissionsFlags selfPermissions, PermissionsFlags rentalPeriodPermissions, PermissionsFlags rolePermissions)
        {
            ModelPermissions = modelPermissions;
            CarsPermissions = carsPermissions;
            UserPermissions = userPermissions;
            SelfPermissions = selfPermissions;
            RentalPeriodPermissions = rentalPeriodPermissions;
            RolePermissions =rolePermissions;
        }
    }
}
