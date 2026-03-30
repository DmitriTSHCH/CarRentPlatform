using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserRepository
    {
        public Task<User?> AddAsync(User user, UserDocumentsData userDocumentsData, UserAccount userAccount, UserCondition userCondition, CancellationToken cancellationToken = default);
        public Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<List<User>> GetUserByFilterAsync(string? firstName, string? lastName,DriverLicenseCategoryFlags? driverLicenseCategory,
                                       DateOnly? licenseExpirationDateWithin, bool? isVerified,
                                       List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating, 
                                       CancellationToken cancellationToken = default);
        public Task<bool> UpdatePasswordAsync(Guid userId, string hashedPassword, CancellationToken cancellationToken = default);
        public Task<string?> UpdatePhoneNumberAsync(Guid userId, string phoneNumber, CancellationToken cancellationToken = default);
        public Task<string?> UpdateEmailAsync(Guid userId, string email, CancellationToken cancellationToken = default);
        public Task<string?> GetPhoneNumberByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<string?> GetEmailByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<Guid?> GetIdByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default);
        public Task<Guid?> GetIdByEmailAsync(string email, CancellationToken cancellationToken = default);
        public Task<string?> GetHashedPasswordAsync(string? phoneNumber, string? email, CancellationToken cancellationToken = default);
        public Task<UserCondition?> GetUserConditionByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateUserConditionAsync(Guid userId, bool? isVerified,
                                    UserStatus? userStatus, decimal? rating,
                                    CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateVerificationAsync(Guid userId, bool isVerified, CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateRatingAsync(Guid userId, decimal rating, CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateStatusAsync(Guid userId, UserStatus userStatus, CancellationToken cancellationToken = default);
        public Task<List<UserCondition>> GetUserConditionByFilterAsync(bool? isVerified, List<UserStatus>? userStatuses,
                                                decimal? minRating, decimal? maxRating,
                                                CancellationToken cancellationToken = default);
        public Task<UserDocumentsData?> UpdateUserDocumentsDataAsync(Guid userId, string? firstName, string? lastName, string? passportNumber,
                                      string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory,
                                      DateOnly? licenseExpirationDate, CancellationToken cancellationToken = default);
        public Task<UserDocumentsData?> GetUserDocumentsDataByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<List<UserDocumentsData>> GetUserDocumentsDataByFilterAsync(string? firstName, string? lastName, string? passportNumber,
                                                         string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory,
                                                         DateOnly? licenseExpirationDateWithin, CancellationToken cancellationToken = default);

    }
}
