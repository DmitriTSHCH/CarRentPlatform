using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarPriceDataRepository
    {
        public Task<CarPriceData?> AddAsync(CarPriceData carPriceData, CancellationToken cancellationToken = default);
        public Task<CarPriceData?> UpdateAsync(Guid carId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN, CancellationToken cancellationToken = default);
        public Task<CarPriceData?> GetByIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<List<CarPriceData>> GetByFilterAsync(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN, decimal? minLateReturnPenaltyPerDayBYN, decimal? maxLateReturnPenaltyPerDayBYN, CancellationToken cancellationToken = default);
    }
}
