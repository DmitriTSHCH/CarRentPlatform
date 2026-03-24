using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public UserDocumentsData UserDocumentsData { get; set; }
        public UserCondition UserCondition { get; set; }
        public List<RentalPeriod> Bookings { get; set; } = new();
    }
}