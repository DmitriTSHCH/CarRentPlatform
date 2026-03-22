using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User Update(Guid userId, string? hashedPassword, string? phoneNumber, string? email, bool? isVerified, UserStatus? userStatus, decimal? rating);
        public User UpdatePassword(Guid userId, string hashedPassword);
        public User UpdatePhoneNumber(Guid userId, string phoneNumber);
        public User UpdateEmail(Guid userId, string email);
        public User UpdateRating(Guid userId, decimal rating);
        public User UpdateStatus(Guid userId, UserStatus userStatus);
        public User GetById (Guid userId);
        public List<User> GetByFilter (string? firstName, string? lastName, string? passportNumber, string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory, DateOnly? licenseExpirationDateWithin, string? hashedPassword, string? phoneNumber, string? email, bool? isVerified, List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating);

    }
}
