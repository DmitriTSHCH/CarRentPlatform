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

        public ModelSpecifications Add(ModelSpecifications modelSpecifications)
        {
            _dbContext.Add(modelSpecifications);
            _dbContext.SaveChanges();

            return GetById(modelSpecifications.ModelId);
        }

        public List<ModelSpecifications> GetByFilter(List<Fuel>? fuels, List<CarType>? carTypes,
                                                     int? minNumberOfSeatsWithDriver, float? minTrunkVoluem,
                                                     float? minTankCapacity, float? maxCityConsumptionPer100km,
                                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                                     float? minHighwayRangeKm, bool? isAutomaticTransmission)
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

            return builder.ToList();
        }

        public ModelSpecifications GetById(Guid modelId)
        {
            return _dbContext.ModelSpecifications
                .AsNoTracking()
                .FirstOrDefault(r => r.ModelId == modelId);
        }

        public ModelSpecifications Update(Guid modelId, Fuel? fuel, CarType? carType, int? numberOfSeatsWithDriver,
                                          float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km,
                                          float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm,
                                          bool? isAutomaticTransmission)
        {
            var builder = _dbContext.ModelSpecifications
                .Where(m => m.ModelId == modelId);

            if (carType != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.CarType, carType));
            }

            if (fuel != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.Fuel, fuel));
            }

            if (numberOfSeatsWithDriver != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.NumberOfSeatsWithDriver, numberOfSeatsWithDriver));
            }

            if (trunkVoluem != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.TrunkVoluem, trunkVoluem));
            }

            if (tankCapacity != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.TankCapacity, tankCapacity));
            }

            if (cityConsumptionPer100km != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.CityConsumptionPer100km, cityConsumptionPer100km));
            }

            if (highwayConsumptionPer100km != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.HighwayConsumptionPer100km, highwayConsumptionPer100km));
            }

            if (cityRangeKm != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.CityRangeKm, cityRangeKm));
            }

            if (highwayRangeKm != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.HighwayRangeKm, highwayRangeKm));
            }

            if (isAutomaticTransmission != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.IsAutomaticTransmission, isAutomaticTransmission));
            }

            return GetById(modelId);
        }
    }
}
