using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IModelSpecificationsRepository
    {
        public Task<ModelSpecifications?> AddAsync(ModelSpecifications modelSpecifications, CancellationToken cancellationToken = default);
        public Task<ModelSpecifications?> UpdateAsync(Guid modelId, Fuel? fuel, CarType? carType, int? numberOfSeatsWithDriver,
                                          float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km,
                                          float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm,
                                          bool? isAutomaticTransmission, CancellationToken cancellationToken = default);
        public Task<ModelSpecifications?> GetByIdAsync(Guid modelId, CancellationToken cancellationToken = default);
        public Task<List<ModelSpecifications>> GetByFilterAsync(List<Fuel>? fuels, List<CarType>? carTypes,
                                                     int? minNumberOfSeatsWithDriver, float? minTrunkVoluem,
                                                     float? minTankCapacity, float? maxCityConsumptionPer100km,
                                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                                     float? minHighwayRangeKm, bool? isAutomaticTransmission, 
                                                     CancellationToken cancellationToken = default);
    }
}
