using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IRoleRepository
    {
        public Task<Role> AddAsync(Role role, CancellationToken cancellationToken = default);
        public Task<Role> UpdateAsync(Guid roleId, string? name, PermissionsFlags? modelPermissions,
                           PermissionsFlags? carsPermissions, PermissionsFlags? userPermissions,
                           PermissionsFlags? rentalPeriodPermissions, PermissionsFlags? rolePermissions,
                           CancellationToken cancellationToken = default);
        public Task<Role> GetByIdAsync(Guid roleId, CancellationToken cancellationToken = default);
    }
}
