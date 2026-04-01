using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum UserStatus { Active, Banned }
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
        public UserCondition(Guid userId)
        {
            UserId = userId;
            IsVerified = false;
            UserStatus = UserStatus.Active;
            Rating = maxRating - 1;
        }
    }
}
