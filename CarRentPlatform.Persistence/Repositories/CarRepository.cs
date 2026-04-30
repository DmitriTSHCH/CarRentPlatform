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

        public async Task<Car?> AddAsync(Car car, CarPriceData carPriceData, CarReservationData carReservationData, CancellationToken cancellationToken)
        {
            _dbContext.Add(car);
            await _dbContext.SaveChangesAsync(cancellationToken);

            _dbContext.Add(carPriceData);
            _dbContext.Add(carReservationData);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return await GetCarByIdAsync(car.CarId, cancellationToken);
        }

        public Task<Car?> UpdateAsync(Guid carId, Guid? modelId, CarColor? carColor, decimal? pricePerDayBYN,
                                      decimal? lateReturnPenaltyPerDayBYN, CarReservationStatus? carReservationStatus,
                                      int? serviceTime, CancellationToken cancellationToken = default)
        {
            UpdateCarPriceDataAsync(carId, pricePerDayBYN, lateReturnPenaltyPerDayBYN, cancellationToken);
            UpdateCarReservationDataAsync(carId, carReservationStatus, serviceTime, cancellationToken);
            return UpdateCarAsync(carId, modelId, carColor, cancellationToken);
        }

        public async Task<Car?> UpdateCarAsync(Guid carId, Guid? modelId, CarColor? carColor, CancellationToken cancellationToken)
        {
            var builder = _dbContext.Cars
                .Where(m => m.CarId == carId);

            if (modelId != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.ModelId, modelId), cancellationToken);
            }

            if (carColor != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.CarColor, carColor), cancellationToken);
            }

            return await GetCarByIdAsync(carId, cancellationToken);
        }

        public async Task<CarPriceData?> UpdateCarPriceDataAsync(Guid carId, decimal? pricePerDayBYN,
                                                                 decimal? lateReturnPenaltyPerDayBYN,
                                                                 CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarPriceDatas
                .Where(m => m.CarId == carId);

            if (pricePerDayBYN != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.PricePerDayBYN, pricePerDayBYN), cancellationToken);
            }

            if (lateReturnPenaltyPerDayBYN != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.LateReturnPenaltyPerDayBYN, lateReturnPenaltyPerDayBYN), cancellationToken);
            }

            return await GetCarPriceDataByIdAsync(carId, cancellationToken);
        }

        public async Task<CarReservationData?> UpdateCarReservationDataAsync(Guid carId,
                                                                             CarReservationStatus? carReservationStatus,
                                                                             int? serviceTimeHours,
                                                                             CancellationToken cancellationToken)
        {
            var builder = _dbContext.CarReservationDatas
                .Where(m => m.CarId == carId);

            if (carReservationStatus != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CarReservationStatus, carReservationStatus), cancellationToken);
            }

            if (serviceTimeHours != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.ServiceTimeHours, serviceTimeHours), cancellationToken);
            }

            return await GetCarReservationDataByIdAsync(carId, cancellationToken);
        }

        public async Task<Car?> GetCarByIdAsync(Guid carId, CancellationToken cancellationToken)
        {
            return await _dbContext.Cars
                .Include(c => c.Model)
                .Include(c => c.CarPriceData)
                .Include(c => c.CarReservationData)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CarId == carId, cancellationToken);
        }

        public async Task<CarPriceData?> GetCarPriceDataByIdAsync(Guid carId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CarPriceDatas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CarId == carId, cancellationToken);
        }

        public async Task<CarReservationData?> GetCarReservationDataByIdAsync(Guid carId, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Include(r => r.OccupiedPeriods)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.CarId == carId, cancellationToken);
        }

        public async Task<List<Car>> GetCarByFilterAsync(List<string>? brands, List<string>? models, 
                                                List<CarColor>? carColors, CancellationToken cancellationToken)
        {
            var builder = _dbContext.Cars
                .AsNoTracking();

            if (carColors != null && carColors.Count > 0)
            {
                builder = builder.Where(c => carColors.Contains(c.CarColor));
            }

            if (brands != null && brands.Count > 0)
            {
                builder = builder.Where(c => brands.Contains(c.Model.Brand));
            }

            if (models != null && models.Count > 0)
            {
                builder = builder.Where(c => models.Contains(c.Model.ModelName));
            }

            builder = builder.Include(c => c.Model)
                .Include(c => c.CarPriceData)
                .Include(c => c.CarReservationData);

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<List<Car>> GetCarByFilterAsync(List<string>? brands, List<string>? models, List<CarColor>? carColors,
                                     List<CarType>? carTypes, List<Fuel>? fuels, int? minNumberOfSeatsWithDriver,
                                     float? minTrunkVoluem, float? minTankCapacity, float? maxCityConsumptionPer100km,
                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                     float? minHighwayRangeKm, bool? isAutomaticTransmission, decimal? maxPricePerDayBYN,
                                     DateTime? dateTimeStartNewPeriod, DateTime? dateTimeEndNewPeriod, 
                                     CancellationToken cancellationToken)
        {
            var builder = _dbContext.Cars
                .AsNoTracking();

            if (carColors != null && carColors.Count > 0)
            {
                builder = builder.Where(c => carColors.Contains(c.CarColor));
            }

            if (brands != null && brands.Count > 0)
            {
                builder = builder.Where(c => brands.Contains(c.Model.Brand));
            }

            if (models != null && models.Count > 0)
            {
                builder = builder.Where(c => models.Contains(c.Model.ModelName));
            }

            if (carTypes != null && carTypes.Count > 0)
            {
                builder = builder.Where(c => carTypes.Contains(c.Model.ModelSpecifications.CarType));
            }

            if (fuels != null && fuels.Count > 0)
            {
                builder = builder.Where(c => fuels.Contains(c.Model.ModelSpecifications.Fuel));
            }

            if (minNumberOfSeatsWithDriver != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.NumberOfSeatsWithDriver >= minNumberOfSeatsWithDriver);
            }

            if (minTrunkVoluem != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.TrunkVoluem >= minTrunkVoluem);
            }

            if (minTankCapacity != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.TankCapacity >= minTankCapacity);
            }

            if (maxCityConsumptionPer100km != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.CityConsumptionPer100km <= maxCityConsumptionPer100km);
            }

            if (maxHighwayConsumptionPer100km != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.HighwayConsumptionPer100km <= maxHighwayConsumptionPer100km);
            }

            if (minCityRangeKm != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.CityRangeKm >= minCityRangeKm);
            }

            if (minHighwayRangeKm != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.HighwayRangeKm >= minHighwayRangeKm);
            }

            if (maxPricePerDayBYN != null)
            {
                builder = builder.Where(c => c.CarPriceData.PricePerDayBYN <= maxPricePerDayBYN);
            }

            if (isAutomaticTransmission != null)
            {
                builder = builder.Where(c => c.Model.ModelSpecifications.IsAutomaticTransmission == isAutomaticTransmission);
            }

            if (dateTimeStartNewPeriod != null && dateTimeEndNewPeriod != null)
            {
                builder = builder.Where(c => !c
                .CarReservationData
                .OccupiedPeriods
                .Any(p => (EF.Functions.DateDiffHour(p.DateTimeEnd, dateTimeStartNewPeriod)) < c.CarReservationData.ServiceTimeHours && 
                          (EF.Functions.DateDiffHour(dateTimeEndNewPeriod, p.DateTimeStart)) < c.CarReservationData.ServiceTimeHours));
            }

            builder = builder.Include(c => c.Model)
                .Include(c => c.CarPriceData)
                .Include(c => c.CarReservationData);

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<List<CarPriceData>> GetCarPriceDataByFilterAsync(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN,
                                              decimal? minLateReturnPenaltyPerDayBYN,
                                              decimal? maxLateReturnPenaltyPerDayBYN,
                                              CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarPriceDatas
                .AsNoTracking();

            if (minPricePerDayBYN != null)
            {
                builder = builder.Where(p => p.PricePerDayBYN >= minPricePerDayBYN);
            }

            if (maxPricePerDayBYN != null)
            {
                builder = builder.Where(p => p.PricePerDayBYN <= maxPricePerDayBYN);
            }

            if (minLateReturnPenaltyPerDayBYN != null)
            {
                builder = builder.Where(p => p.LateReturnPenaltyPerDayBYN >= minLateReturnPenaltyPerDayBYN);
            }

            if (maxLateReturnPenaltyPerDayBYN != null)
            {
                builder = builder.Where(p => p.LateReturnPenaltyPerDayBYN <= maxLateReturnPenaltyPerDayBYN);
            }

            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<List<CarReservationData>> GetCarReservationDataByFreePeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Where(c => !c
                .OccupiedPeriods
                .Any(p => (EF.Functions.DateDiffHour(p.DateTimeEnd, dateTimeStart)) < c.ServiceTimeHours &&
                          (EF.Functions.DateDiffHour(dateTimeEnd, p.DateTimeStart)) < c.ServiceTimeHours))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<CarReservationData>> GetCarReservationDataByOccupiedPeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Where(c => c
                .OccupiedPeriods
                .Any(p => (EF.Functions.DateDiffHour(p.DateTimeEnd, dateTimeStart)) < c.ServiceTimeHours &&
                          (EF.Functions.DateDiffHour(dateTimeEnd, p.DateTimeStart)) < c.ServiceTimeHours))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<CarReservationData>> GetCarReservationDataByStatusAsync(List<CarReservationStatus> carReservationStatuses, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Include(r => r.OccupiedPeriods)
                .AsNoTracking()
                .Where(r => carReservationStatuses.Contains(r.CarReservationStatus))
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsCarFreeForThePeriod(Guid carId, DateTime startDateTime, DateTime endDateTime, CancellationToken cancellationToken = default)
        {
            var serviceTimeHours = (await _dbContext.CarReservationDatas
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CarId == carId, cancellationToken))
                .ServiceTimeHours;

            return !((await _dbContext.CarReservationDatas
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CarId == carId, cancellationToken))
                .OccupiedPeriods
                .Any(p => (EF.Functions.DateDiffHour(p.DateTimeEnd, startDateTime)) < serviceTimeHours &&
                          (EF.Functions.DateDiffHour(endDateTime, p.DateTimeStart)) < serviceTimeHours));
        }
    }
}
