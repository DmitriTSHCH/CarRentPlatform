using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    internal class UserConditionRepository : IUserConditionRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public UserConditionRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserCondition Add(UserCondition userCondition)
        {
            _dbContext.Add(userCondition);
            _dbContext.SaveChanges();

            return GetById(userCondition.UserId);
        }

        public UserCondition GetById(Guid userId)
        {
            return _dbContext.UserConditions
                .AsNoTracking()
                .FirstOrDefault(r => r.UserId == userId);
        }

        public List<UserCondition> GetByFilter(bool? isVerified, List<UserStatus>? userStatuses, decimal? minRating, decimal? maxRating)
        {
            throw new NotImplementedException();
        }

        public UserCondition Update(Guid userId, bool? isVerified,
                           UserStatus? userStatus, decimal? rating)
        {
            var builder = _dbContext.UserConditions
                .Where(m => m.UserId == userId);

            if (isVerified != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.IsVerified, isVerified));
            }

            if (userStatus != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.UserStatus, userStatus));
            }

            if (rating != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.Rating, rating));
            }

            return GetById(userId);
        }

        public UserCondition UpdateRating(Guid userId, decimal rating)
        {
            throw new NotImplementedException();
        }

        public UserCondition UpdateStatus(Guid userId, UserStatus userStatus)
        {
            throw new NotImplementedException();
        }

        public UserCondition UpdateVerification(Guid userId, bool isVerified)
        {
            throw new NotImplementedException();
        }
    }
}
