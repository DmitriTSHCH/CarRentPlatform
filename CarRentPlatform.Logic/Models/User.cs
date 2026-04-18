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

        public RoleNameId RoleNameId { get; set; }
        public Role Role { get; set; }

        public DateTime DateTimeCreation { get; private set; } = DateTime.UtcNow;

        public User()
        {

        }

        public User(RoleNameId roleNameId)
        {
            RoleNameId = roleNameId;
        }

        public User AddCondition(User user, UserCondition userCondition)
        { 
            user.UserCondition = userCondition;
            return user;
        }
        public User AddDocumentsData(User user, UserDocumentsData userDocumentsData)
        { 
            user.UserDocumentsData = userDocumentsData;
            return user;
        }
        public bool Equals(User user1, User user2)
        {
            return (user1.UserId == user2.UserId) &&
                (user1.RoleNameId == user2.RoleNameId) &&
                (user1.DateTimeCreation == user2.DateTimeCreation) &&
                (user1.UserCondition.Equals(user1.UserCondition, user2.UserCondition)) &&
                (user1.UserDocumentsData.Equals(user1.UserDocumentsData, user2.UserDocumentsData));
        }
    }
}