using System;
using System.Collections.Generic;
using System.Text;
using CarRentPlatform.Logic.Models;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarRepository
    {
        public Task<Car?> AddAsync(Car car, CancellationToken cancellationToken = default);
        public Task<Car?> UpdateAsync(Guid carId, Guid? modelId, CarColor? carColor, CancellationToken cancellationToken = default);
        public Task<Car?> GetByIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<List<Car>> GetByFilterAsync(List<string>? brands, List<string>? models, List<CarColor>? carColors, CancellationToken cancellationToken = default);
        public Task<List<Car>> GetByFilterAsync(List<string>? brands, List<string>? models, List<CarColor>? carColors,
                                     List<CarType>? carTypes, List<Fuel>? fuels, int? minNumberOfSeatsWithDriver,
                                     float? minTrunkVoluem, float? minTankCapacity, float? maxCityConsumptionPer100km,
                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                     float? minHighwayRangeKm, bool? IsAutomaticTransmission, decimal? maxPricePerDayBYN, 
                                     DateTime? dateTimeStartNewPeriod, DateTime? dateTimeEndNewPeriod, CancellationToken cancellationToken = default);
    }
}
