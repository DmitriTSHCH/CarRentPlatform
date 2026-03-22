using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserDocumentsDataRepository
    {
        public UserDocumentsData Add(UserDocumentsData userDocumentsData);
        public UserDocumentsData Update(Guid userId, string? firstName, string? lastName, string? passportNumber, string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory, DateOnly? licenseExpirationDate);
        public UserDocumentsData GetById(Guid userId);
        public List<UserDocumentsData> GetByFilter(string? firstName, string? lastName, string? passportNumber, string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory, DateOnly? licenseExpirationDateWithin);
    }
}
