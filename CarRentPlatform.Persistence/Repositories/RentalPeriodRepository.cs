using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class RentalPeriodRepository : IRentalPeriodRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public RentalPeriodRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RentalPeriod?> AddAsync(RentalPeriod rentalPeriod, CancellationToken cancellationToken)
        {
            _dbContext.AddAsync(rentalPeriod, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(rentalPeriod.PeriodId, cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByCarIdAsync(Guid carId, CancellationToken cancellationToken)
        {
            return await _dbContext.RentalPeriods
                .AsNoTracking()
                .Where(r => r.CarId == carId)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByFilterAsync(DateTime? beforeDateTime, DateTime? afterDateTime, Guid? carId,
                                                         Guid? userId, List<PeriodStatus>? periodStatuses,
                                                         decimal? minRentalPriceBYN, decimal? maxRentalPriceBYN, 
                                                         CancellationToken cancellationToken)
        {
            var builder = _dbContext.RentalPeriods
                .AsNoTracking();

            if (beforeDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeEnd <= beforeDateTime);
            }

            if (afterDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeStart >= afterDateTime);
            }

            if (carId != null)
            {
                builder = builder.Where(c => c.CarId == carId);
            }

            if (userId != null)
            {
                builder = builder.Where(c => c.UserId == userId);
            }

            if (periodStatuses != null)
            {
                builder = builder.Where(c => periodStatuses.Contains(c.PeriodStatus));
            }

            if (minRentalPriceBYN != null)
            {
                builder = builder.Where(c => c.RentalPriceBYN >= minRentalPriceBYN);
            }

            if (maxRentalPriceBYN != null)
            {
                builder = builder.Where(c => c.RentalPriceBYN <= maxRentalPriceBYN);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<RentalPeriod?> GetByIdAsync(Guid periodId, CancellationToken cancellationToken)
        {
            return await _dbContext.RentalPeriods
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.PeriodId == periodId, cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByOccupiedPeriodAsync(DateTime? beforeDateTime, DateTime? afterDateTime, CancellationToken cancellationToken)
        {
            var builder = _dbContext.RentalPeriods
                .AsNoTracking();

            if (beforeDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeEnd <= beforeDateTime);
            }

            if (afterDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeStart >= afterDateTime);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _dbContext.RentalPeriods
                .AsNoTracking()
                .Where(r => r.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<RentalPeriod?> UpdateAsync(Guid periodId, DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId,
                                   Guid? userId, PeriodStatus? periodStatus, decimal? rentalPriceBYN, CancellationToken cancellationToken)
        {
            var builder = _dbContext.RentalPeriods
                .Where(m => m.PeriodId == periodId);

            if (dateTimeStart != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.DateTimeStart, dateTimeStart), cancellationToken);
            }

            if (dateTimeEnd != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.DateTimeEnd, dateTimeEnd), cancellationToken);
            }

            if (carId != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CarId, carId), cancellationToken);
            }

            if (userId != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.UserId, userId), cancellationToken);
            }

            if (periodStatus != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.PeriodStatus, periodStatus), cancellationToken);
            }

            if (rentalPriceBYN != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.RentalPriceBYN, rentalPriceBYN), cancellationToken);
            }

            return await GetByIdAsync(periodId, cancellationToken);
        }
    }
}
