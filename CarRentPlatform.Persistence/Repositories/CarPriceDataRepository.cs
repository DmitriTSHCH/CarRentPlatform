using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class CarPriceDataRepository : ICarPriceDataRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public CarPriceDataRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarPriceData?> AddAsync(CarPriceData carPriceData, CancellationToken cancellationToken = default)
        {
            _dbContext.AddAsync(carPriceData, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(carPriceData.CarId, cancellationToken);
        }

        public async Task<List<CarPriceData>> GetByFilterAsync(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN,
                                              decimal? minLateReturnPenaltyPerDayBYN,
                                              decimal? maxLateReturnPenaltyPerDayBYN,
                                              CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarPriceDatas
                .AsNoTracking();

            if (minPricePerDayBYN != null)
            {
                builder = builder.Where(p => p.PricePerDayBYN >= minPricePerDayBYN);
            }

            if (maxPricePerDayBYN != null)
            {
                builder = builder.Where(p => p.PricePerDayBYN <= maxPricePerDayBYN);
            }

            if (minLateReturnPenaltyPerDayBYN != null)
            {
                builder = builder.Where(p => p.LateReturnPenaltyPerDayBYN >= minLateReturnPenaltyPerDayBYN);
            }

            if (maxLateReturnPenaltyPerDayBYN != null)
            {
                builder = builder.Where(p => p.LateReturnPenaltyPerDayBYN <= maxLateReturnPenaltyPerDayBYN);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<CarPriceData?> GetByIdAsync(Guid carId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CarPriceDatas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CarId == carId, cancellationToken);
        }

        public async Task<CarPriceData?> UpdateAsync(Guid carId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN, CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarPriceDatas
                .Where(m => m.CarId == carId);

            if (pricePerDayBYN != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.PricePerDayBYN, pricePerDayBYN), cancellationToken);
            }

            if (lateReturnPenaltyPerDayBYN != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.LateReturnPenaltyPerDayBYN, lateReturnPenaltyPerDayBYN), cancellationToken);
            }

            return await GetByIdAsync(carId, cancellationToken);
        }
    }
}
