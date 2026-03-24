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

        public void Add(UserAccount userAccount)
        {
            _dbContext.Add(userAccount);
            _dbContext.SaveChanges();
        }

        public string GetEmailById(Guid userId)
        {
            return _dbContext.UserAccounts
                .FirstOrDefault(a => a.UserId == userId)
                .Email;
        }

        public Guid GetIdByEmail(string email)
        {
            return _dbContext.UserAccounts
                .FirstOrDefault(a => a.Email == email)
                .UserId;
        }

        public Guid GetIdByPhoneNumber(string phoneNumber)
        {
            return _dbContext.UserAccounts
                .FirstOrDefault(a => a.PhoneNumber == phoneNumber)
                .UserId;
        }

        public string GetPhoneNumberById(Guid userId)
        {
            return _dbContext.UserAccounts
                .FirstOrDefault(a => a.UserId == userId)
                .PhoneNumber;
        }

        public bool IsCorrectPasswodr(string phoneNumber, string hashedPassword)
        {
            return _dbContext.UserAccounts
                .FirstOrDefault(a => a.PhoneNumber == phoneNumber)
                .HashedPassword == hashedPassword;
        }

        public string UpdateEmail(Guid userId, string email)
        {
            _dbContext.UserAccounts
                .Where(m => m.UserId == userId)
                .ExecuteUpdate(r => r.SetProperty(p => p.Email, email));

            return GetEmailById(userId);
        }

        public void UpdatePassword(Guid userId, string hashedPassword)
        {
            _dbContext.UserAccounts
                .Where(m => m.UserId == userId)
                .ExecuteUpdate(r => r.SetProperty(p => p.HashedPassword, hashedPassword));
        }

        public string UpdatePhoneNumber(Guid userId, string phoneNumber)
        {
            _dbContext.UserAccounts
                .Where(m => m.UserId == userId)
                .ExecuteUpdate(r => r.SetProperty(p => p.PhoneNumber, phoneNumber));

            return GetPhoneNumberById(userId);
        }
    }
}
