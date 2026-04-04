using CarRentPlatform.Application.Intefaces;
using CarRentPlatform.Application.Intefaces.Auth;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
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

        public async Task<string> Login(string phoneNumber, string password, CancellationToken cancellationToken)
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

            return token;
        }

        public async Task<bool> Registration(string phoneNumber, string email, string password, string firstName,
                                       string lastName, string passportNumber, string driverLicenseNumber,
                                       DriverLicenseCategoryFlags driverLicenseCategory, DateOnly licenseExpirationDate,
                                       CancellationToken cancellationToken)
        {
            var hasedPassword = _passwordHasher.Generate(password);

            var user = new User();
            var userDocuments = new UserDocumentsData(user.UserId, firstName, lastName, passportNumber,
                                                      driverLicenseNumber, driverLicenseCategory, licenseExpirationDate);
            var userAccount = new UserAccount(user.UserId, hasedPassword, phoneNumber, email);
            var userCondition = new UserCondition(user.UserId);

            var addedUser = _userRepository.AddAsync(user, userDocuments, userAccount, userCondition, cancellationToken);

            return (await addedUser == user && addedUser != null);
        }
    }
}
