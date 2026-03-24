using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User GetById (Guid userId);
        public List<User> GetByFilter (string? firstName, string? lastName,DriverLicenseCategoryFlags? driverLicenseCategory,
                                       DateOnly? licenseExpirationDateWithin, bool? isVerified,
                                       List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating);

    }
}
