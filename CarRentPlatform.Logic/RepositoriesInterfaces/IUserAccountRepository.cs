using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserAccountRepository
    {
        public void Add(UserAccount userAccount);
        public void UpdatePassword(Guid userId, string hashedPassword);
        public string UpdatePhoneNumber(Guid userId, string phoneNumber);
        public string UpdateEmail(Guid userId, string email);
        public string GetPhoneNumberById(Guid userId);
        public string GetEmailById(Guid userId);
        public Guid GetIdByPhoneNumber(string phoneNumber);
        public Guid GetIdByEmail(string email);
        public bool IsCorrectPasswodr(string phoneNumber, string hashedPassword);
    }
}
