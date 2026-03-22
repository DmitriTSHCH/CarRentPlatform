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
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
        public DriverLicenseCategoryFlags DriverLicenseCategory { get; set; }
        public DateOnly LicenseExpirationDate { get; set; }
    }
}
