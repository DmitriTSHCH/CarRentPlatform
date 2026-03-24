using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public CarRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Car Add(Car car)
        {
            _dbContext.Add(car);
            _dbContext.SaveChanges();

            return GetById(car.CarId);
        }

        public List<Car> GetByFilter(List<string>? brands, List<string>? models, List<CarColor>? carColors)
        {
            var builder = _dbContext.Cars
                .AsNoTracking();

            if (carColors != null)
            {
                builder = builder.Where(c => carColors.Contains(c.CarColor));
            }

            if (brands != null)
            {
                builder = builder.Where(c => brands.Contains(c.CarModel.Brand));
            }

            if (models != null)
            {
                builder = builder.Where(c => models.Contains(c.CarModel.Model));
            }

            builder.Include(c => c.CarModel)
                .Include(c => c.CarPriceData)
                .Include(c => c.CarReservationData);

            return builder.ToList();
        }

        public List<Car> GetByFilter(List<string>? brands, List<string>? models, List<CarColor>? carColors,
                                     List<CarType>? carTypes, List<Fuel>? fuels, int? minNumberOfSeatsWithDriver,
                                     float? minTrunkVoluem, float? minTankCapacity, float? maxCityConsumptionPer100km,
                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                     float? minHighwayRangeKm, bool? isAutomaticTransmission, decimal? maxPricePerDayBYN,
                                     DateTime? dateTimeStartNewPeriod, DateTime? dateTimeEndNewPeriod)
        {
            var builder = _dbContext.Cars
                .AsNoTracking();

            if (carColors != null)
            {
                builder = builder.Where(c => carColors.Contains(c.CarColor));
            }

            if (brands != null)
            {
                builder = builder.Where(c => brands.Contains(c.CarModel.Brand));
            }

            if (models != null)
            {
                builder = builder.Where(c => models.Contains(c.CarModel.Model));
            }

            if (carTypes != null)
            {
                builder = builder.Where(c => carTypes.Contains(c.CarModel.ModelSpecifications.CarType));
            }

            if (fuels != null)
            {
                builder = builder.Where(c => fuels.Contains(c.CarModel.ModelSpecifications.Fuel));
            }

            if (minNumberOfSeatsWithDriver != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.NumberOfSeatsWithDriver >= minNumberOfSeatsWithDriver);
            }

            if (minTrunkVoluem != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.TrunkVoluem >= minTrunkVoluem);
            }

            if (minTankCapacity != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.TankCapacity >= minTankCapacity);
            }

            if (maxCityConsumptionPer100km != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.CityConsumptionPer100km <= maxCityConsumptionPer100km);
            }

            if (maxHighwayConsumptionPer100km != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.HighwayConsumptionPer100km <= maxHighwayConsumptionPer100km);
            }

            if (minCityRangeKm != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.CityRangeKm >= minCityRangeKm);
            }

            if (minHighwayRangeKm != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.HighwayRangeKm >= minHighwayRangeKm);
            }

            if (maxPricePerDayBYN != null)
            {
                builder = builder.Where(c => c.CarPriceData.PricePerDayBYN <= maxPricePerDayBYN);
            }

            if (isAutomaticTransmission != null)
            {
                builder = builder.Where(c => c.CarModel.ModelSpecifications.IsAutomaticTransmission == isAutomaticTransmission);
            }

            if (dateTimeStartNewPeriod != null && dateTimeEndNewPeriod != null)
            {
                builder = builder.Where(c => !c
                .CarReservationData
                .OccupiedPeriods
                .Any(p => dateTimeStartNewPeriod < (p.DateTimeEnd + c.CarReservationData.ServiceTime) && dateTimeEndNewPeriod > (p.DateTimeStart - c.CarReservationData.ServiceTime)));
            }

            builder.Include(c => c.CarModel)
                .Include(c => c.CarPriceData)
                .Include(c => c.CarReservationData);

            return builder.ToList();
        }

        public Car GetById(Guid carId)
        {
            return _dbContext.Cars
                .Include(c => c.CarModel)
                .Include(c => c.CarPriceData)
                .Include(c => c.CarReservationData)
                .AsNoTracking()
                .FirstOrDefault(m => m.CarId == carId);
        }

        public Car Update(Guid carId, Guid? modelId, CarColor? carColor )
        {
            var builder = _dbContext.Cars
                .Where(m => m.CarId == carId);

            if (modelId != null)
            {
                builder.ExecuteUpdate(m => m.SetProperty(p => p.ModelId, modelId));
            }

            if (carColor != null)
            {
                builder.ExecuteUpdate(m => m.SetProperty(p => p.CarColor, carColor));
            }

            return GetById(carId);
        }
    }
}
