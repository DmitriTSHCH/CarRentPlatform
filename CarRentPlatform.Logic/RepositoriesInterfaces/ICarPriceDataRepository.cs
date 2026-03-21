using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarPriceDataRepository
    {
        public void Add(CarPriceData carPriceData);
        public void Update(Guid CarId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN);
        public CarPriceData GetById(Guid carId);
    }
}
