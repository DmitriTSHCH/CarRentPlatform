using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentPlatform.Application.Interfaces
{
    public interface ICarService
    {
        public Task<Car?> AddAsync(Car car, CarPriceData carPriceData, CarReservationData carReservationData, CancellationToken cancellationToken = default);
        public Task<Car?> UpdateAsync(Guid carId, Guid? modelId, CarColor? carColor, decimal? pricePerDayBYN,
                                      decimal? lateReturnPenaltyPerDayBYN, CarReservationStatus? carReservationStatus,
                                      TimeSpan? serviceTime, CancellationToken cancellationToken = default);
        public Task<Car?> UpdateCarAsync(Guid carId, Guid? modelId, CarColor? carColor, CancellationToken cancellationToken = default);
        public Task<CarPriceData?> UpdateCarPriceDataAsync(Guid carId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN, CancellationToken cancellationToken = default);
        public Task<CarReservationData?> UpdateCarReservationDataAsync(Guid carId, CarReservationStatus? carReservationStatus,
                                         TimeSpan? serviceTime, CancellationToken cancellationToken = default);
        public Task<Car?> GetCarByIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<CarPriceData?> GetCarPriceDataByIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<CarReservationData?> GetCarReservationDataByIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<List<Car>> GetCarByFilterAsync(List<string>? brands, List<string>? models, List<CarColor>? carColors, CancellationToken cancellationToken = default);
        public Task<List<Car>> GetCarByFilterAsync(List<string>? brands, List<string>? models, List<CarColor>? carColors,
                                     List<CarType>? carTypes, List<Fuel>? fuels, int? minNumberOfSeatsWithDriver,
                                     float? minTrunkVoluem, float? minTankCapacity, float? maxCityConsumptionPer100km,
                                     float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                     float? minHighwayRangeKm, bool? IsAutomaticTransmission, decimal? maxPricePerDayBYN,
                                     DateTime? dateTimeStartNewPeriod, DateTime? dateTimeEndNewPeriod, CancellationToken cancellationToken = default);
        public Task<List<CarPriceData>> GetCarPriceDataByFilterAsync(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN,
                                                                     decimal? minLateReturnPenaltyPerDayBYN, decimal? maxLateReturnPenaltyPerDayBYN,
                                                                     CancellationToken cancellationToken = default);
        public Task<List<CarReservationData>> GetCarReservationDataByFreePeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken = default);
        public Task<List<CarReservationData>> GetCarReservationDataByOccupiedPeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken = default);
        public Task<List<CarReservationData>> GetCarReservationDataByStatusAsync(List<CarReservationStatus> carReservationStatuses, CancellationToken cancellationToken = default);
    }
}
