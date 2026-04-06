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

        public async Task<User?> AddAsync(User user, UserDocumentsData userDocumentsData, UserAccount userAccount,
                                          UserCondition userCondition, CancellationToken cancellationToken)
        {
            _dbContext.AddAsync(user, cancellationToken);
            _dbContext.AddAsync(userCondition, cancellationToken);
            _dbContext.AddAsync(userAccount, cancellationToken);
            _dbContext.AddAsync(userDocumentsData, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetUserByIdAsync(user.UserId, cancellationToken);
        }

        public async Task<List<User>> GetUserByFilterAsync(string? firstName, string? lastName, 
                                                            DriverLicenseCategoryFlags? driverLicenseCategory,
                                                            DateOnly? licenseExpirationDateWithin, bool? isVerified,
                                                            List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating, 
                                                            CancellationToken cancellationToken)
        {
            var builder = _dbContext.Users
                .Include(u => u.UserDocumentsData)
                .Include(u => u.UserCondition)
                .Include(u => u.Bookings)
                .Include(u => u.Role);

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

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .Include(u => u.UserDocumentsData)
                .Include(u => u.UserCondition)
                .Include(u => u.Bookings)
                .Include(u => u.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken);
        }

        public async Task<string?> GetEmailByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return (await _dbContext.UserAccounts
                .FirstOrDefaultAsync(a => a.UserId == userId, cancellationToken))?
                .Email;
        }

        public async Task<string?> GetHashedPasswordAsync(string? phoneNumber, string? email, CancellationToken cancellationToken = default)
        {
            if (phoneNumber == null && email == null)
            {
                return null;
            }
            return (await _dbContext.UserAccounts
                .FirstOrDefaultAsync(a =>
                (phoneNumber != null && a.PhoneNumber == phoneNumber) ||
                (email != null && a.Email == email), cancellationToken))?
                .HashedPassword;
        }

        public async Task<Guid?> GetIdByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return (await _dbContext.UserAccounts
                .FirstOrDefaultAsync(a => a.Email == email, cancellationToken))?
                .UserId;
        }

        public async Task<Guid?> GetIdByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
        {
            return (await _dbContext.UserAccounts
                .FirstOrDefaultAsync(a => a.PhoneNumber == phoneNumber, cancellationToken))?
                .UserId;
        }

        public async Task<string?> GetPhoneNumberByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return (await _dbContext.UserAccounts
                .FirstOrDefaultAsync(a => a.UserId == userId, cancellationToken))?
                .PhoneNumber;
        }

        public async Task<string?> UpdateEmailAsync(Guid userId, string email, CancellationToken cancellationToken)
        {
            _dbContext.UserAccounts
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.Email, email), cancellationToken);

            return await GetEmailByIdAsync(userId, cancellationToken);
        }

        public async Task<bool> UpdatePasswordAsync(Guid userId, string hashedPassword, CancellationToken cancellationToken)
        {
            _dbContext.UserAccounts
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.HashedPassword, hashedPassword), cancellationToken);

            return await _dbContext.UserAccounts
                .AnyAsync(a => a.UserId == userId, cancellationToken);
        }

        public async Task<string?> UpdatePhoneNumberAsync(Guid userId, string phoneNumber, CancellationToken cancellationToken)
        {
            _dbContext.UserAccounts
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.PhoneNumber, phoneNumber), cancellationToken);

            return await GetPhoneNumberByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> GetUserConditionByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbContext.UserConditions
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken);
        }

        public async Task<List<UserCondition>> GetUserConditionByFilterAsync(bool? isVerified, List<UserStatus>? userStatuses,
                                               decimal? minRating, decimal? maxRating, CancellationToken cancellationToken)
        {
            var builder = _dbContext.UserConditions
                .AsNoTracking();

            if (isVerified != null)
            {
                builder.Where(u => u.IsVerified == isVerified);
            }

            if (userStatuses != null)
            {
                builder.Where(u => userStatuses.Contains(u.UserStatus));
            }

            if (minRating != null)
            {
                builder.Where(u => u.Rating >= minRating);
            }

            if (maxRating != null)
            {
                builder.Where(u => u.Rating <= maxRating);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<UserCondition?> UpdateUserConditionAsync(Guid userId, bool? isVerified,
                           UserStatus? userStatus, decimal? rating, CancellationToken cancellationToken)
        {
            var builder = _dbContext.UserConditions
                .Where(m => m.UserId == userId);

            if (isVerified != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.IsVerified, isVerified), cancellationToken);
            }

            if (userStatus != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.UserStatus, userStatus), cancellationToken);
            }

            if (rating != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.Rating, rating), cancellationToken);
            }

            return await GetUserConditionByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> UpdateRatingAsync(Guid userId, decimal rating, CancellationToken cancellationToken)
        {
            _dbContext.UserConditions
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.Rating, rating), cancellationToken);

            return await GetUserConditionByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> UpdateStatusAsync(Guid userId, UserStatus userStatus, CancellationToken cancellationToken)
        {
            _dbContext.UserConditions
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.UserStatus, userStatus), cancellationToken);

            return await GetUserConditionByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> UpdateVerificationAsync(Guid userId, bool isVerified, CancellationToken cancellationToken)
        {
            _dbContext.UserConditions
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.IsVerified, isVerified), cancellationToken);

            return await GetUserConditionByIdAsync(userId, cancellationToken);
        }

        public async Task<UserDocumentsData?> UpdateUserDocumentsDataAsync(Guid userId, string? firstName, string? lastName,
                                                                     string? passportNumber, string? driverLicenseNumber,
                                                                     DriverLicenseCategoryFlags? driverLicenseCategory,
                                                                     DateOnly? licenseExpirationDate,
                                                                     CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.UserDocumentsDatas
                .Where(m => m.UserId == userId);

            if (firstName != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.FirstName, firstName), cancellationToken);
            }

            if (lastName != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.LastName, lastName), cancellationToken);
            }

            if (passportNumber != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.PassportNumber, passportNumber), cancellationToken);
            }

            if (driverLicenseNumber != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.DriverLicenseNumber, driverLicenseNumber), cancellationToken);
            }

            if (driverLicenseCategory != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.DriverLicenseCategory, driverLicenseCategory), cancellationToken);
            }

            if (licenseExpirationDate != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.LicenseExpirationDate, licenseExpirationDate), cancellationToken);
            }

            return await GetUserDocumentsDataByIdAsync(userId, cancellationToken);
        }

        public async Task<UserDocumentsData?> GetUserDocumentsDataByIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.UserDocumentsDatas
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken);
        }

        public async Task<List<UserDocumentsData>> GetUserDocumentsDataByFilterAsync(string? firstName, string? lastName,
                                                                                     string? passportNumber, string? driverLicenseNumber,
                                                                                     DriverLicenseCategoryFlags? driverLicenseCategory,
                                                                                     DateOnly? licenseExpirationDateWithin,
                                                                                     CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.UserDocumentsDatas;

            if (firstName != null)
            {
                builder.Where(u => EF.Functions.Like(u.FirstName, firstName));
            }

            if (lastName != null)
            {
                builder.Where(u => EF.Functions.Like(u.LastName, lastName));
            }

            if (passportNumber != null)
            {
                builder.Where(u => u.PassportNumber == passportNumber);
            }

            if (driverLicenseNumber != null)
            {
                builder.Where(u => u.DriverLicenseNumber == driverLicenseNumber);
            }

            if (driverLicenseCategory != null)
            {
                builder.Where(u => (u.DriverLicenseCategory & driverLicenseCategory) == driverLicenseCategory);
            }

            if (licenseExpirationDateWithin != null)
            {
                builder.Where(u => u.LicenseExpirationDate > licenseExpirationDateWithin);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<Role> GetRoleByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            {
                return (await _dbContext.Users
                    .Include(u => u.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken))
                    .Role;
            }
        }
    }
}
