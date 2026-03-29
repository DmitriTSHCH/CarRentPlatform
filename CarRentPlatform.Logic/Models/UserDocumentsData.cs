using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    [Flags]
    public enum DriverLicenseCategoryFlags
    { 
        None = 0,
        A = 1,  // Мотоциклы
        B = 2,  // Легковые
        C = 4,  // Грузовые
        D = 8,  // Автобусы
        M = 16,  // Мопеды
    }
    public class UserDocumentsData
    {
        public Guid UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PassportNumber { get; private set; }
        public string DriverLicenseNumber { get; private set; }
        public DriverLicenseCategoryFlags DriverLicenseCategory { get; private set; }
        public DateOnly LicenseExpirationDate { get; private set; }

        public UserDocumentsData()
        {

        }
        public UserDocumentsData(Guid userId, string firstName, string lastName, string passportNumber, string driverLicenseNumber
                                 DriverLicenseCategoryFlags driverLicenseCategory, DateOnly licenseExpirationDate)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
            DriverLicenseNumber = driverLicenseNumber;
            DriverLicenseCategory = driverLicenseCategory;
            LicenseExpirationDate = licenseExpirationDate;
        }
    }
}
