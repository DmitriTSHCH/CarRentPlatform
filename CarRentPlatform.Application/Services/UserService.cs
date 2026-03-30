using CarRentPlatform.Application.Intefaces;
using CarRentPlatform.Application.Intefaces.Auth;
using CarRentPlatform.Logic.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CarRentPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService (IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<JwtSecurityToken> Login(string phoneNumber, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> Registration(string phoneNumber, string email, string password, string firstName,
        //                               string lastName, string passportNumber, string driverLicenseNumber,
        //                               DriverLicenseCategoryFlags driverLicenseCategory, DateOnly licenseExpirationDate,
        //                               CancellationToken cancellationToken)
        //{
            //var hasedPassword = _passwordHasher.Generate(password);

            //var user = new User();
            //var userDocuments = new UserDocumentsData(user.UserId, firstName, lastName, passportNumber,
            //                                          driverLicenseNumber, driverLicenseCategory, licenseExpirationDate);
            //return false;
        //}
    }
}
