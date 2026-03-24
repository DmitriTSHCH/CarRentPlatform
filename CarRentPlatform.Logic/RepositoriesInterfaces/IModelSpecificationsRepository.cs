using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IModelSpecificationsRepository
    {
        public ModelSpecifications Add(ModelSpecifications modelSpecifications);
        public ModelSpecifications Update(Guid modelId, Fuel? fuel, CarType? carType, int? numberOfSeatsWithDriver,
                                          float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km,
                                          float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm,
                                          bool? isAutomaticTransmission);
        public ModelSpecifications GetById(Guid modelId);
        public List<ModelSpecifications> GetByFilter(List<Fuel>? fuels, List<CarType>? carTypes,
                                                     int? minNumberOfSeatsWithDriver, float? minTrunkVoluem,
                                                     float? minTankCapacity, float? maxCityConsumptionPer100km,
                                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                                     float? minHighwayRangeKm, bool? isAutomaticTransmission);
    }
}
