using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public Task<User?> AddAsync(User user, CancellationToken cancellationToken = default);
        public Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<List<User>> GetByFilterAsync(string? firstName, string? lastName,DriverLicenseCategoryFlags? driverLicenseCategory,
                                       DateOnly? licenseExpirationDateWithin, bool? isVerified,
                                       List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating, 
                                       CancellationToken cancellationToken = default);

    }
}
