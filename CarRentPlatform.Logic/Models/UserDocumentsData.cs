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
        public UserDocumentsData(Guid userId, string firstName, string lastName, string passportNumber, string driverLicenseNumber,
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

        public bool Equals(UserDocumentsData userDocumentsData1, UserDocumentsData userDocumentsData2)
        {
            return (userDocumentsData1.UserId == userDocumentsData2.UserId) &&
                (userDocumentsData1.FirstName == userDocumentsData2.FirstName) &&
                (userDocumentsData1.LastName == userDocumentsData2.LastName) &&
                (userDocumentsData1.PassportNumber == userDocumentsData2.PassportNumber) &&
                (userDocumentsData1.DriverLicenseNumber == userDocumentsData2.DriverLicenseNumber) &&
                (userDocumentsData1.DriverLicenseCategory == userDocumentsData2.DriverLicenseCategory) &&
                (userDocumentsData1.LicenseExpirationDate == userDocumentsData2.LicenseExpirationDate);
        }
    }
}
