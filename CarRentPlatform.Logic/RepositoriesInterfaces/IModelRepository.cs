using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IModelRepository
    {
        public Task<Model?> AddAsync(Model carModel, ModelSpecifications modelSpecifications, CancellationToken cancellationToken = default);
        public Task<Model?> UpdateModelAsync(Guid modelId, string? brand, string? modelName, CancellationToken cancellationToken = default);
        public Task<ModelSpecifications?> UpdateSpecificationsAsync(Guid modelId, Fuel? fuel, CarType? carType, int? numberOfSeatsWithDriver,
                                                                    float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km,
                                                                    float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm,
                                                                    bool? isAutomaticTransmission, CancellationToken cancellationToken = default);
        public Task<Model?> GetModelByIdAsync(Guid modelId, CancellationToken cancellationToken = default);
        public Task<ModelSpecifications?> GetModelSpecificationsByIdAsync(Guid modelId, CancellationToken cancellationToken = default);
        public Task<List<Model>> GetModelByFilterAsync(List<string>? brands, List<string>? modelNames, CancellationToken cancellationToken = default);
        public Task<List<ModelSpecifications>> GetModelSpecificationsByFilterAsync(List<Fuel>? fuels, List<CarType>? carTypes,
                                                                                int? minNumberOfSeatsWithDriver, float? minTrunkVoluem,
                                                                                float? minTankCapacity, float? maxCityConsumptionPer100km,
                                                                                float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                                                                float? minHighwayRangeKm, bool? isAutomaticTransmission,
                                                                                CancellationToken cancellationToken = default);
    }
}
