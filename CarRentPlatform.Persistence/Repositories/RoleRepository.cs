using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public RoleRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> AddAsync(Role role, CancellationToken cancellationToken = default)
        {
            _dbContext.AddAsync(role, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(role.RoleId, cancellationToken);
        }

        public async Task<Role> GetByIdAsync(Guid roleId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RoleId == roleId, cancellationToken);
        }

        public async Task<Role> UpdateAsync(Guid roleId, string? name, PermissionsFlags? modelPermissions,
                                      PermissionsFlags? carsPermissions, PermissionsFlags? userPermissions,
                                      PermissionsFlags? rentalPeriodPermissions, PermissionsFlags? rolePermissions,
                                      CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.Roles
                .Where(r => r.RoleId == roleId);

            if (name != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.Name, name), cancellationToken);
            }

            if (modelPermissions != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.ModelPermissions, modelPermissions), cancellationToken);
            }

            if (carsPermissions != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CarsPermissions, carsPermissions), cancellationToken);
            }

            if (userPermissions != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.UserPermissions, userPermissions), cancellationToken);
            }

            if (rentalPeriodPermissions != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.RentalPeriodPermissions, rentalPeriodPermissions), cancellationToken);
            }

            if (rolePermissions != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.RolePermissions, rolePermissions), cancellationToken);
            }

            return await GetByIdAsync(roleId, cancellationToken);
        }
    }
}
