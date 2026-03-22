using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarPriceDataRepository
    {
        public CarPriceData Add(CarPriceData carPriceData);
        public CarPriceData Update(Guid carId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN);
        public CarPriceData GetById(Guid carId);
        public List<CarPriceData> GetByFilter(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN, decimal? minLateReturnPenaltyPerDayBYN, decimal? maxLateReturnPenaltyPerDayBYN);
    }
}
