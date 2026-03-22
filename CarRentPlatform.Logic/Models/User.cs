using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum UserStatus { Active, Banned, WaitVerification }
    public class User
    {
        public Guid UserId { get; set; }
        public UserDocumentsData UserDocumentsData { get; set; }
        public string HashedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public UserStatus UserStatus { get; set; }

        [Range(0, 10, ErrorMessage = "Рейтинг должен быть от 0 до 10")]
        public decimal Rating { get; set; }
        public List<RentalPeriod> Bookings { get; set; } = new();
    }
}
