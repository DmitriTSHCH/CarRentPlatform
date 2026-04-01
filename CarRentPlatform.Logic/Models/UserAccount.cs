using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class UserAccount
    {
        public Guid UserId { get; private set; }
        public string HashedPassword { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public UserAccount()
        {

        }
        public UserAccount(Guid userId, string hashedPassword, string phoneNumber, string email)
        {
            UserId = userId;
            HashedPassword = hashedPassword;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
