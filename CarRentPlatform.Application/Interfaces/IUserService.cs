using CarRentPlatform.Application.DtoModels;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Application.Intefaces
{
    public interface IUserService
    {
        public Task<bool> RegistrationAsync(string phoneNumber, string email, string password,
                                 string firstName, string lastName, string passportNumber,
                                 string driverLicenseNumber, DriverLicenseCategoryFlags driverLicenseCategory,
                                 DateOnly licenseExpirationDate, CancellationToken cancellationToken = default);
        public Task<string> LoginAsync(string phoneNumber, string password, HttpContext httpContext, CancellationToken cancellationToken = default);
        public Task<UserPersonalInfoDto> GetPersonalInfoByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<UserDocumentsData> UpdateUserDocumentsDataAsync(Guid userId, string? firstName, string? lastName,
                                                                     string? passportNumber, string? driverLicenseNumber,
                                                                     DriverLicenseCategoryFlags? driverLicenseCategory,
                                                                     DateOnly? licenseExpirationDate,
                                                                     CancellationToken cancellationToken = default);
        public Task<bool> UpdatePasswordAsync(Guid userId, string password, CancellationToken cancellationToken = default);
        public Task<string?> UpdatePhoneNumberAsync(Guid userId, string phoneNumber, CancellationToken cancellationToken = default);
        public Task<string?> UpdateEmailAsync(Guid userId, string email, CancellationToken cancellationToken = default);
        public Task<List<User>> GetUserByFilterAsync(string? firstName, string? lastName, DriverLicenseCategoryFlags? driverLicenseCategory,
                                       DateOnly? licenseExpirationDateWithin, bool? isVerified,
                                       List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating,
                                       CancellationToken cancellationToken = default);
        public Task<bool> CheckPasswordAsync(Guid userId, string password, CancellationToken cancellationToken = default);
    }
}
