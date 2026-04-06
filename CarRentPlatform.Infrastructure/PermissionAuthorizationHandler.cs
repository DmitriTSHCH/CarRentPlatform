using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CarRentPlatform.Infrastructure
{
    internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionAuthorizationHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var userId = context.User.FindFirst("userId")?.Value;

            if (userId == null || !Guid.TryParse(userId,out Guid id))
            {
                return;
            }

            var cancellationToken = _httpContextAccessor.HttpContext?.RequestAborted ?? CancellationToken.None;

            var userRole = await _userRepository.GetRoleByUserIdAsync(Guid.Parse(userId), cancellationToken);

            if ((userRole.ModelPermissions & requirement.ModelPermissions) == requirement.ModelPermissions &&
                (userRole.CarsPermissions & requirement.CarsPermissions) == requirement.CarsPermissions &&
                (userRole.UserPermissions & requirement.UserPermissions) == requirement.UserPermissions &&
                (userRole.SelfPermissions & requirement.SelfPermissions) == requirement.SelfPermissions &&
                (userRole.RentalPeriodPermissions & requirement.RentalPeriodPermissions) == requirement.RentalPeriodPermissions &&
                (userRole.RolePermissions & requirement.RolePermissions) == requirement.RolePermissions)
            {
                context.Succeed(requirement);
            }

        }
    }
}
