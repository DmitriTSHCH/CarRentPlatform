using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserDocumentsDataRepository
    {
        public void Add(UserDocumentsData userDocumentsData);
        public void Update(Guid userId, string firstName, string lastName, string passportNumber, string driverLicenseNumber, DriverLicenseCategory driverLicenseCategory, DateOnly licenseExpirationDate);
        public UserDocumentsData GetById(Guid userId);
    }
}
