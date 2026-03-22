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

        public CarPriceData Add(CarPriceData carPriceData)
        {
            _dbContext.Add(carPriceData);
            _dbContext.SaveChanges();

            return GetById(carPriceData.CarId);
        }

        public List<CarPriceData> GetByFilter(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN, decimal? minLateReturnPenaltyPerDayBYN, decimal? maxLateReturnPenaltyPerDayBYN)
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

            return builder.ToList();
        }

        public CarPriceData GetById(Guid carId)
        {
            return _dbContext.CarPriceDatas
                .AsNoTracking()
                .FirstOrDefault(m => m.CarId == carId);
        }

        public CarPriceData Update(Guid carId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN)
        {
            var builder = _dbContext.CarPriceDatas
                .Where(m => m.CarId == carId);

            if (pricePerDayBYN != null)
            {
                builder.ExecuteUpdate(m => m.SetProperty(p => p.PricePerDayBYN, pricePerDayBYN));
            }

            if (lateReturnPenaltyPerDayBYN != null)
            {
                builder.ExecuteUpdate(m => m.SetProperty(p => p.LateReturnPenaltyPerDayBYN, lateReturnPenaltyPerDayBYN));
            }

            return GetById(carId);
        }
    }
}
