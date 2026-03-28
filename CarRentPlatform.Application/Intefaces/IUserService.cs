using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Application.Intefaces
{
    internal interface IUserService
    {
        public void Registration(string phoneNumber, string email, string password,
                                 string firstName, string lastName, string passportNumber,
                                 string driverLicenseNumber, DriverLicenseCategoryFlags DriverLicenseCategory,
                                 DateOnly LicenseExpirationDate);
        public void Login(string phoneNumber, string password);
    }
}
