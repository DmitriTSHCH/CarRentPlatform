using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserConditionRepository
    {
        public UserCondition Add(UserCondition userCondition);
        public UserCondition GetById(Guid userId);
        public UserCondition Update(Guid userId, bool? isVerified,
                           UserStatus? userStatus, decimal? rating);
        public UserCondition UpdateVerification(Guid userId, bool isVerified);
        public UserCondition UpdateRating(Guid userId, decimal rating);
        public UserCondition UpdateStatus(Guid userId, UserStatus userStatus);
        public List<UserCondition> GetByFilter( bool? isVerified, List<UserStatus>? userStatuses, 
                                                decimal? minRating, decimal? maxRating);
    }
}
