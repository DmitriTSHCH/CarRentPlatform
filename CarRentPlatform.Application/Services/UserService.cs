using CarRentPlatform.Application.DtoModels;
using CarRentPlatform.Application.Intefaces;
using CarRentPlatform.Application.Intefaces.Auth;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserRepository _userRepository;

        public UserService (IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IUserRepository userRepository)
        {
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        public async Task<string> LoginAsync(string phoneNumber, string password, HttpContext httpContext, CancellationToken cancellationToken = default)
        {
            var exeptionInvalidLoginPasword = new Exception("Неверный логин или пароль");

            var hashedPassword = await _userRepository.GetHashedPasswordAsync(phoneNumber, null, cancellationToken);

            if (hashedPassword == null)
            {
                throw exeptionInvalidLoginPasword;
            }

            var isVerified = _passwordHasher.Verify(password, hashedPassword);
            
            if (isVerified == false)
            {
                throw exeptionInvalidLoginPasword;
            }

            var userId = await _userRepository.GetIdByPhoneNumberAsync(phoneNumber);

            if (userId == null)
            {
                throw exeptionInvalidLoginPasword;
            }

            var token = _jwtProvider.Generate(userId.Value);

            httpContext.Response.Cookies.Append("LogData", token);

            return token;
        }

        public async Task<bool> RegistrationAsync(string phoneNumber, string email, string password, string firstName,
                                       string lastName, string passportNumber, string driverLicenseNumber,
                                       DriverLicenseCategoryFlags driverLicenseCategory, DateOnly licenseExpirationDate,
                                       CancellationToken cancellationToken = default)
        {
            var hasedPassword = _passwordHasher.Generate(password);

            var user = new User(RoleNameId.User);

            var userDocumentsData = new UserDocumentsData(user.UserId, firstName, lastName, passportNumber,
                                                      driverLicenseNumber, driverLicenseCategory, licenseExpirationDate);
            var userCondition = new UserCondition(user.UserId, true);

            user = user.AddDocumentsData(user, userDocumentsData);
            user = user.AddCondition(user, userCondition);

            var addedUser = await _userRepository.AddUserAsync(user, cancellationToken);

            var userAccount = new UserAccount(addedUser.UserId, hasedPassword, phoneNumber, email);

            var IsUserAccountAdded = await _userRepository.AddUserAccountAsync(userAccount, cancellationToken);

            return ((addedUser.Equals(addedUser, user)) && (addedUser != null) && IsUserAccountAdded);
        }

        public async Task<UserPersonalInfoDto> GetPersonalInfoByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

            var email = await _userRepository.GetEmailByIdAsync(userId, cancellationToken);
            var phoneNumber = await _userRepository.GetPhoneNumberByIdAsync(userId, cancellationToken);

            var userInfo = new UserPersonalInfoDto(user, email, phoneNumber);

            return userInfo;
        }

        public async Task<UserDocumentsData> UpdateUserDocumentsDataAsync(Guid userId, string? firstName, string? lastName, string? passportNumber, string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory, DateOnly? licenseExpirationDate, CancellationToken cancellationToken = default)
        {
            return await _userRepository.UpdateUserDocumentsDataAsync(userId, firstName, lastName, passportNumber, driverLicenseNumber, driverLicenseCategory, licenseExpirationDate, cancellationToken);
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, string password, CancellationToken cancellationToken = default)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            return await _userRepository.UpdatePasswordAsync(userId, hashedPassword, cancellationToken);
        }

        public async Task<string?> UpdatePhoneNumberAsync(Guid userId, string phoneNumber, CancellationToken cancellationToken = default)
        {
            return await _userRepository.UpdatePhoneNumberAsync(userId, phoneNumber, cancellationToken);
        }

        public async Task<string?> UpdateEmailAsync(Guid userId, string email, CancellationToken cancellationToken = default)
        {
            return await _userRepository.UpdateEmailAsync(userId, email, cancellationToken);
        }

        public async Task<List<User>> GetUserByFilterAsync(string? firstName, string? lastName, DriverLicenseCategoryFlags? driverLicenseCategory, DateOnly? licenseExpirationDateWithin, bool? isVerified, List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating, CancellationToken cancellationToken = default)
        {
            return await _userRepository.GetUserByFilterAsync(firstName, lastName, driverLicenseCategory, licenseExpirationDateWithin, isVerified, userStatuses, minRating, maxRating, cancellationToken);
        }
        public async Task<bool> CheckPasswordAsync(Guid userId, string password, CancellationToken cancellationToken = default)
        {
            var exeptionInvalidLoginPasword = new Exception("Неверный логин или пароль");

            var hashedPassword = await _userRepository.GetHashedPasswordAsync(userId, cancellationToken);

            if (hashedPassword == null)
            {
                throw exeptionInvalidLoginPasword;
            }

            var isVerified = _passwordHasher.Verify(password, hashedPassword);
            return isVerified;
        }
    }
}
