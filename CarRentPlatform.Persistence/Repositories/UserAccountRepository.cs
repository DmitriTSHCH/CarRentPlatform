using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    internal class UserAccountRepository : IUserAccountRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public UserAccountRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(UserAccount userAccount, CancellationToken cancellationToken)
        {
            _dbContext.AddAsync(userAccount, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await _dbContext.UserAccounts
                .AnyAsync(a => a.UserId == userAccount.UserId, cancellationToken);
        }

        public async Task<string?> GetEmailByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return ( await _dbContext.UserAccounts
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
                (email !=null && a.Email == email), cancellationToken))?
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
    }
}
