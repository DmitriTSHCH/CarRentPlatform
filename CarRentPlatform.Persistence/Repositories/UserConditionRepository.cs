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

        public async Task<UserCondition?> AddAsync(UserCondition userCondition, CancellationToken cancellationToken)
        {
            _dbContext.AddAsync(userCondition, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(userCondition.UserId, cancellationToken);
        }

        public async Task<UserCondition?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbContext.UserConditions
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserId == userId, cancellationToken);
        }

        public async Task<List<UserCondition>> GetByFilterAsync(bool? isVerified, List<UserStatus>? userStatuses, 
                                               decimal? minRating, decimal? maxRating, CancellationToken cancellationToken)
        {
            var builder = _dbContext.UserConditions
                .AsNoTracking();

            if (isVerified != null)
            {
                builder.Where(u => u.IsVerified == isVerified);
            }

            if (userStatuses != null)
            {
                builder.Where(u => userStatuses.Contains(u.UserStatus));
            }

            if (minRating != null)
            {
                builder.Where(u => u.Rating >= minRating);
            }

            if (maxRating != null)
            {
                builder.Where(u => u.Rating <= maxRating);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<UserCondition?> UpdateAsync(Guid userId, bool? isVerified,
                           UserStatus? userStatus, decimal? rating, CancellationToken cancellationToken)
        {
            var builder = _dbContext.UserConditions
                .Where(m => m.UserId == userId);

            if (isVerified != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.IsVerified, isVerified), cancellationToken);
            }

            if (userStatus != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.UserStatus, userStatus), cancellationToken);
            }

            if (rating != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.Rating, rating), cancellationToken);
            }

            return await GetByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> UpdateRatingAsync(Guid userId, decimal rating, CancellationToken cancellationToken)
        {
            _dbContext.UserConditions
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.Rating, rating), cancellationToken);

            return await GetByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> UpdateStatusAsync(Guid userId, UserStatus userStatus, CancellationToken cancellationToken)
        {
            _dbContext.UserConditions
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.UserStatus, userStatus), cancellationToken);

            return await GetByIdAsync(userId, cancellationToken);
        }

        public async Task<UserCondition?> UpdateVerificationAsync(Guid userId, bool isVerified, CancellationToken cancellationToken)
        {
            _dbContext.UserConditions
                .Where(m => m.UserId == userId)
                .ExecuteUpdateAsync(r => r.SetProperty(p => p.IsVerified, isVerified), cancellationToken);

            return await GetByIdAsync(userId, cancellationToken);
        }
    }
}
