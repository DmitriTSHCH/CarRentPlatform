using System;
using System.Collections.Generic;
using System.Text;
using CarRentPlatform.Logic.Models;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarRepository
    {
        public Car Add(Car car);
        public Car Update(Guid carId, Guid? modelId, CarColor? carColor);
        public Car GetById(Guid carId);
        public List<Car> GetByFilter(List<string>? brands, List<string>? models, List<CarColor>? carColors);
        public List<Car> GetByFilter(List<string>? brands, List<string>? models, List<CarColor>? carColors,
                                     List<CarType>? carTypes, List<Fuel>? fuels, int? minNumberOfSeatsWithDriver,
                                     float? minTrunkVoluem, float? minTankCapacity, float? maxCityConsumptionPer100km,
                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                     float? minHighwayRangeKm, bool? IsAutomaticTransmission, decimal? maxPricePerDayBYN, 
                                     DateTime? dateTimeStartNewPeriod, DateTime? dateTimeEndNewPeriod);
    }
}
