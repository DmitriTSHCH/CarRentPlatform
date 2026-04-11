using CarRentPlatform.Infrastructure;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace CarRentPlatform.API.Policy
{
    public static class PolicyConfigurator
    {
        public static void AddPolicies(this AuthorizationOptions options)
        {
            options.AddPolicy(PolicyNames.ReadModels, p => p.Requirements.Add(new PermissionRequirement(PermissionsFlags.Read, 0, 0, 0, 0, 0)));
            options.AddPolicy(PolicyNames.CreateModels, p => p.Requirements.Add(new PermissionRequirement(PermissionsFlags.Create, 0, 0, 0, 0, 0)));
            options.AddPolicy(PolicyNames.UpdateModels, p => p.Requirements.Add(new PermissionRequirement(PermissionsFlags.Updete, 0, 0, 0, 0, 0)));
            options.AddPolicy(PolicyNames.DeleteModels, p => p.Requirements.Add(new PermissionRequirement(PermissionsFlags.Delete, 0, 0, 0, 0, 0)));

            options.AddPolicy(PolicyNames.ReadCars, p => p.Requirements.Add(new PermissionRequirement(0, PermissionsFlags.Read, 0, 0, 0, 0)));
            options.AddPolicy(PolicyNames.CreateCars, p => p.Requirements.Add(new PermissionRequirement(0, PermissionsFlags.Create, 0, 0, 0, 0)));
            options.AddPolicy(PolicyNames.UpdateCars, p => p.Requirements.Add(new PermissionRequirement(0, PermissionsFlags.Updete, 0, 0, 0, 0)));
            options.AddPolicy(PolicyNames.DeleteCars, p => p.Requirements.Add(new PermissionRequirement(0, PermissionsFlags.Delete, 0, 0, 0, 0)));

            options.AddPolicy(PolicyNames.ReadUsers, p => p.Requirements.Add(new PermissionRequirement(0, 0, PermissionsFlags.Read, 0, 0, 0)));
            options.AddPolicy(PolicyNames.CreateUsers, p => p.Requirements.Add(new PermissionRequirement(0, 0, PermissionsFlags.Create, 0, 0, 0)));
            options.AddPolicy(PolicyNames.UpdateUsers, p => p.Requirements.Add(new PermissionRequirement(0, 0, PermissionsFlags.Updete, 0, 0, 0)));
            options.AddPolicy(PolicyNames.DeleteUsers, p => p.Requirements.Add(new PermissionRequirement(0, 0, PermissionsFlags.Delete, 0, 0, 0)));

            options.AddPolicy(PolicyNames.ReadSelf, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, PermissionsFlags.Read, 0, 0)));
            options.AddPolicy(PolicyNames.UpdateSelf, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, PermissionsFlags.Updete, 0, 0)));

            options.AddPolicy(PolicyNames.ReadRental, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, PermissionsFlags.Read, 0)));
            options.AddPolicy(PolicyNames.CreateRental, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, PermissionsFlags.Create, 0)));
            options.AddPolicy(PolicyNames.UpdateRental, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, PermissionsFlags.Updete, 0)));
            options.AddPolicy(PolicyNames.DeleteRental, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, PermissionsFlags.Delete, 0)));

            options.AddPolicy(PolicyNames.ReadRoles, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, 0, PermissionsFlags.Read)));
            options.AddPolicy(PolicyNames.CreateRoles, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, 0, PermissionsFlags.Create)));
            options.AddPolicy(PolicyNames.UpdateRoles, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, 0, PermissionsFlags.Updete)));
            options.AddPolicy(PolicyNames.DeleteRoles, p => p.Requirements.Add(new PermissionRequirement(0, 0, 0, 0, 0, PermissionsFlags.Delete)));

            options.AddPolicy(PolicyNames.FullAdmin, p => p.Requirements.Add(new PermissionRequirement((PermissionsFlags)15, (PermissionsFlags)15, (PermissionsFlags)15, (PermissionsFlags)15, (PermissionsFlags)15, (PermissionsFlags)15)));
        }
    }
}
