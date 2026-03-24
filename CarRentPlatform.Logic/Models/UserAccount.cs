using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class UserAccount
    {
        public Guid UserId { get; set; }
        public string HashedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
