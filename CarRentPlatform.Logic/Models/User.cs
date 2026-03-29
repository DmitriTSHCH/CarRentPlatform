using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();

        private readonly UserDocumentsData _userDocumentsData;
        private readonly UserCondition _userCondition;
        private readonly List<RentalPeriod> _bookings = new();

        private readonly DateTime _dateTimeCreation = DateTime.UtcNow;

        public User()
        {

        }
    }
}