using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();

        public UserDocumentsData UserDocumentsData { get; private set; }
        public UserCondition UserCondition { get; private set; }
        public List<RentalPeriod> Bookings { get; private set; } = new();

        public DateTime DateTimeCreation { get; private set; } = DateTime.UtcNow;

        public User()
        {

        }
    }
}