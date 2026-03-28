using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IUserConditionRepository
    {
        public Task<UserCondition?> AddAsync(UserCondition userCondition, CancellationToken cancellationToken = default);
        public Task<UserCondition?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateAsync(Guid userId, bool? isVerified,
                                    UserStatus? userStatus, decimal? rating,
                                    CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateVerificationAsync(Guid userId, bool isVerified, CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateRatingAsync(Guid userId, decimal rating, CancellationToken cancellationToken = default);
        public Task<UserCondition?> UpdateStatusAsync(Guid userId, UserStatus userStatus, CancellationToken cancellationToken = default);
        public Task<List<UserCondition>> GetByFilterAsync( bool? isVerified, List<UserStatus>? userStatuses, 
                                                decimal? minRating, decimal? maxRating, 
                                                CancellationToken cancellationToken = default);
    }
}
