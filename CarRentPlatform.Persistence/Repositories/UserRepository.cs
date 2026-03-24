using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public UserRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();

            return GetById(user.UserId);
        }

        public List<User> GetByFilter(string? firstName, string? lastName, DriverLicenseCategoryFlags? driverLicenseCategory,
                                       DateOnly? licenseExpirationDateWithin, bool? isVerified,
                                       List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating)
        {
            var builder = _dbContext.Users
                .Include(u => u.UserDocumentsData)
                .Include(u => u.UserCondition)
                .Include(u => u.Bookings);

            if (firstName != null)
            {
                builder.Where(u => EF.Functions.Like(u.UserDocumentsData.FirstName, firstName));
            }

            if (lastName != null)
            {
                builder.Where(u => EF.Functions.Like(u.UserDocumentsData.LastName, lastName));
            }

            if (driverLicenseCategory != null)
            {
                builder.Where(u => (u.UserDocumentsData.DriverLicenseCategory & driverLicenseCategory) == driverLicenseCategory);
            }

            if (licenseExpirationDateWithin != null)
            {
                builder.Where(u => u.UserDocumentsData.LicenseExpirationDate > licenseExpirationDateWithin);
            }

            if (isVerified != null)
            {
                builder.Where(u => u.UserCondition.IsVerified == isVerified);
            }

            if (userStatuses != null)
            {
                builder.Where(u => userStatuses.Contains(u.UserCondition.UserStatus));
            }

            if (minRating != null)
            {
                builder.Where(u => u.UserCondition.Rating >= minRating);
            }

            if (maxRating != null)
            {
                builder.Where(u => u.UserCondition.Rating <= maxRating);
            }

            return builder.ToList();
        }

        public User GetById(Guid userId)
        {
            return _dbContext.Users
                .Include(u => u.UserDocumentsData)
                .Include(u => u.UserCondition)
                .Include(u => u.Bookings)
                .AsNoTracking()
                .FirstOrDefault(r => r.UserId == userId);
        }
    }
}
