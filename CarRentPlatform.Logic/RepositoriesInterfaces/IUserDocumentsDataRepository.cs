using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserDocumentsDataRepository
    {
        public Task<UserDocumentsData?> AddAsync(UserDocumentsData userDocumentsData, CancellationToken cancellationToken = default);
        public Task<UserDocumentsData?> UpdateAsync(Guid userId, string? firstName, string? lastName, string? passportNumber,
                                              string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory,
                                              DateOnly? licenseExpirationDate, CancellationToken cancellationToken = default);
        public Task<UserDocumentsData?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<List<UserDocumentsData>> GetByFilterAsync(string? firstName, string? lastName, string? passportNumber,
                                                         string? driverLicenseNumber, DriverLicenseCategoryFlags? driverLicenseCategory,
                                                         DateOnly? licenseExpirationDateWithin, CancellationToken cancellationToken = default);
    }
}
