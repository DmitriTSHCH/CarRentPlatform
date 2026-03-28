using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace CarRentPlatform.Application.Intefaces
{
    internal interface IUserService
    {
        public Task Registration(string phoneNumber, string email, string password,
                                 string firstName, string lastName, string passportNumber,
                                 string driverLicenseNumber, DriverLicenseCategoryFlags DriverLicenseCategory,
                                 DateOnly LicenseExpirationDate, CancellationToken cancellationToken);
        public Task<JwtSecurityToken> Login(string phoneNumber, string password, CancellationToken cancellationToken);
    }
}
