using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum UserStatus { Active, Banned, Deleted, WaitVerification }
    public class UserCondition
    {
        private const int maxRating = 10;

        public Guid UserId { get; private set; }
        public bool IsVerified { get; private set; } 
        public UserStatus UserStatus { get; private set; } 

        [Range(0, maxRating, ErrorMessage = "Рейтинг должен быть от 0 до 10")]
        public decimal Rating { get; private set; }

        public UserCondition()
        {

        }
        public UserCondition(Guid userId, bool isNewUser)
        {
            UserId = userId;

            if (isNewUser)
            {
                IsVerified = false;
                UserStatus = UserStatus.Active;
                Rating = maxRating - 1;
            }
        }

        public bool Equals(UserCondition userCondition1, UserCondition userCondition2)
        {
            return (userCondition1.UserId == userCondition2.UserId) &&
                (userCondition1.IsVerified == userCondition2.IsVerified) &&
                (userCondition1.UserStatus == userCondition2.UserStatus) &&
                (userCondition1.Rating == userCondition2.Rating);
        }
    }
}
