using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public ModelRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Model?> AddAsync(Model carModel, ModelSpecifications modelSpecifications, CancellationToken cancellationToken = default)
        {
            _dbContext.AddAsync(modelSpecifications, cancellationToken);
            _dbContext.AddAsync(carModel, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetModelByIdAsync(carModel.ModelId, cancellationToken);
        }

        public async Task<List<Model>> GetModelByFilterAsync(List<string>? brands, List<string>? models, CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarModels
                .AsNoTracking();

            if (brands != null)
            {
                builder = builder.Where(m => brands.Contains(m.Brand));
            }

            if (models != null)
            {
                builder = builder.Where(m => models.Contains(m.ModelName));
            }
                
            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<List<ModelSpecifications>> GetModelSpecificationsByFilterAsync(List<Fuel>? fuels, List<CarType>? carTypes,
                                                     int? minNumberOfSeatsWithDriver, float? minTrunkVoluem,
                                                     float? minTankCapacity, float? maxCityConsumptionPer100km,
                                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                                     float? minHighwayRangeKm, bool? isAutomaticTransmission,
                                                     CancellationToken cancellationToken)
        {
            var builder = _dbContext.ModelSpecifications
                .AsNoTracking();

            if (carTypes != null)
            {
                builder = builder.Where(c => carTypes.Contains(c.CarType));
            }

            if (fuels != null)
            {
                builder = builder.Where(c => fuels.Contains(c.Fuel));
            }

            if (minNumberOfSeatsWithDriver != null)
            {
                builder = builder.Where(c => c.NumberOfSeatsWithDriver >= minNumberOfSeatsWithDriver);
            }

            if (minTrunkVoluem != null)
            {
                builder = builder.Where(c => c.TrunkVoluem >= minTrunkVoluem);
            }

            if (minTankCapacity != null)
            {
                builder = builder.Where(c => c.TankCapacity >= minTankCapacity);
            }

            if (maxCityConsumptionPer100km != null)
            {
                builder = builder.Where(c => c.CityConsumptionPer100km <= maxCityConsumptionPer100km);
            }

            if (maxHighwayConsumptionPer100km != null)
            {
                builder = builder.Where(c => c.HighwayConsumptionPer100km <= maxHighwayConsumptionPer100km);
            }

            if (minCityRangeKm != null)
            {
                builder = builder.Where(c => c.CityRangeKm >= minCityRangeKm);
            }

            if (minHighwayRangeKm != null)
            {
                builder = builder.Where(c => c.HighwayRangeKm >= minHighwayRangeKm);
            }

            if (isAutomaticTransmission != null)
            {
                builder = builder.Where(c => c.IsAutomaticTransmission == isAutomaticTransmission);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<Model?> GetModelByIdAsync(Guid modelId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CarModels
                .Include(m => m.ModelSpecifications)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ModelId == modelId, cancellationToken);
        }

        public async Task<ModelSpecifications?> GetModelSpecificationsByIdAsync(Guid modelId, CancellationToken cancellationToken)
        {
            return await _dbContext.ModelSpecifications
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ModelId == modelId, cancellationToken);
        }


        public async Task<Model?> UpdateModelAsync(Guid modelId, string? brand, string? model, CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarModels
                .Where(m => m.ModelId == modelId);

            if (brand != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.Brand, brand), cancellationToken);
            }

            if (model != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.ModelName, model), cancellationToken);
            }

            return await GetModelByIdAsync(modelId, cancellationToken);
        }
        public async Task<ModelSpecifications?> UpdateSpecificationsAsync(Guid modelId, Fuel? fuel, CarType? carType, int? numberOfSeatsWithDriver,
                                          float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km,
                                          float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm,
                                          bool? isAutomaticTransmission, CancellationToken cancellationToken)
        {
            var builder = _dbContext.ModelSpecifications
                .Where(m => m.ModelId == modelId);

            if (carType != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CarType, carType), cancellationToken);
            }

            if (fuel != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.Fuel, fuel), cancellationToken);
            }

            if (numberOfSeatsWithDriver != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.NumberOfSeatsWithDriver, numberOfSeatsWithDriver), cancellationToken);
            }

            if (trunkVoluem != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.TrunkVoluem, trunkVoluem), cancellationToken);
            }

            if (tankCapacity != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.TankCapacity, tankCapacity), cancellationToken);
            }

            if (cityConsumptionPer100km != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CityConsumptionPer100km, cityConsumptionPer100km), cancellationToken);
            }

            if (highwayConsumptionPer100km != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.HighwayConsumptionPer100km, highwayConsumptionPer100km), cancellationToken);
            }

            if (cityRangeKm != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CityRangeKm, cityRangeKm), cancellationToken);
            }

            if (highwayRangeKm != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.HighwayRangeKm, highwayRangeKm), cancellationToken);
            }

            if (isAutomaticTransmission != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.IsAutomaticTransmission, isAutomaticTransmission), cancellationToken);
            }

            return await GetModelSpecificationsByIdAsync(modelId, cancellationToken);
        }
    }
}
