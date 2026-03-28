using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class ModelSpecificationsRepository : IModelSpecificationsRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public ModelSpecificationsRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ModelSpecifications?> AddAsync(ModelSpecifications modelSpecifications, CancellationToken cancellationToken)
        {
            _dbContext.AddAsync(modelSpecifications, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(modelSpecifications.ModelId, cancellationToken);
        }

        public async Task<List<ModelSpecifications>> GetByFilterAsync(List<Fuel>? fuels, List<CarType>? carTypes,
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

        public async Task<ModelSpecifications?> GetByIdAsync(Guid modelId, CancellationToken cancellationToken)
        {
            return await _dbContext.ModelSpecifications
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ModelId == modelId, cancellationToken);
        }

        public async Task<ModelSpecifications?> UpdateAsync(Guid modelId, Fuel? fuel, CarType? carType, int? numberOfSeatsWithDriver,
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

            return await GetByIdAsync(modelId, cancellationToken);
        }
    }
}
