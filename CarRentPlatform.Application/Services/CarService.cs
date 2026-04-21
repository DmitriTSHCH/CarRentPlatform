using CarRentPlatform.Application.Interfaces;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentPlatform.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        { 
            _carRepository = carRepository;
        }
        public async Task<Car?> AddAsync(Car car, CarPriceData carPriceData, CarReservationData carReservationData, CancellationToken cancellationToken = default)
        {
            return await _carRepository.AddAsync(car, carPriceData, carReservationData, cancellationToken);
        }

        public async Task<List<Car>> GetCarByFilterAsync(List<string>? brands, List<string>? models, List<CarColor>? carColors, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarByFilterAsync(brands, models, carColors, cancellationToken);
        }

        public async Task<List<Car>> GetCarByFilterAsync(List<string>? brands, List<string>? models,
                                                         List<CarColor>? carColors, List<CarType>? carTypes,
                                                         List<Fuel>? fuels, int? minNumberOfSeatsWithDriver,
                                                         float? minTrunkVoluem, float? minTankCapacity,
                                                         float? maxCityConsumptionPer100km,
                                                         float? maxHighwayConsumptionPer100km, float? minCityRangeKm,
                                                         float? minHighwayRangeKm, bool? IsAutomaticTransmission,
                                                         decimal? maxPricePerDayBYN, DateTime? dateTimeStartNewPeriod,
                                                         DateTime? dateTimeEndNewPeriod,
                                                         CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarByFilterAsync(brands, models, carColors, carTypes, fuels, minNumberOfSeatsWithDriver,
                                                            minTrunkVoluem, minTankCapacity, maxCityConsumptionPer100km, maxHighwayConsumptionPer100km,
                                                            minCityRangeKm, minHighwayRangeKm, IsAutomaticTransmission, maxPricePerDayBYN,
                                                            dateTimeStartNewPeriod, dateTimeEndNewPeriod, cancellationToken);
        }

        public async Task<Car?> GetCarByIdAsync(Guid carId, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarByIdAsync(carId, cancellationToken);
        }

        public async Task<List<CarPriceData>> GetCarPriceDataByFilterAsync(decimal? minPricePerDayBYN, decimal? maxPricePerDayBYN, decimal? minLateReturnPenaltyPerDayBYN, decimal? maxLateReturnPenaltyPerDayBYN, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarPriceDataByFilterAsync(minPricePerDayBYN, maxPricePerDayBYN, minLateReturnPenaltyPerDayBYN, maxLateReturnPenaltyPerDayBYN, cancellationToken);
        }

        public async Task<CarPriceData?> GetCarPriceDataByIdAsync(Guid carId, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarPriceDataByIdAsync(carId, cancellationToken);
        }

        public async Task<List<CarReservationData>> GetCarReservationDataByFreePeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarReservationDataByFreePeriodAsync(dateTimeStart, dateTimeEnd, cancellationToken);
        }

        public async Task<CarReservationData?> GetCarReservationDataByIdAsync(Guid carId, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarReservationDataByIdAsync(carId, cancellationToken);
        }

        public async Task<List<CarReservationData>> GetCarReservationDataByOccupiedPeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarReservationDataByOccupiedPeriodAsync(dateTimeStart, dateTimeEnd, cancellationToken);
        }

        public async Task<List<CarReservationData>> GetCarReservationDataByStatusAsync(List<CarReservationStatus> carReservationStatuses, CancellationToken cancellationToken = default)
        {
            return await _carRepository.GetCarReservationDataByStatusAsync(carReservationStatuses, cancellationToken);
        }

        public async Task<Car?> UpdateAsync(Guid carId, Guid? modelId, CarColor? carColor, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN, CarReservationStatus? carReservationStatus, int? serviceTimeHours, CancellationToken cancellationToken = default)
        {
            return await _carRepository.UpdateAsync(carId, modelId, carColor, pricePerDayBYN, lateReturnPenaltyPerDayBYN, carReservationStatus, serviceTimeHours, cancellationToken);
        }

        public async Task<Car?> UpdateCarAsync(Guid carId, Guid? modelId, CarColor? carColor, CancellationToken cancellationToken = default)
        {
            return await _carRepository.UpdateCarAsync(carId, modelId, carColor, cancellationToken);
        }

        public async Task<CarPriceData?> UpdateCarPriceDataAsync(Guid carId, decimal? pricePerDayBYN, decimal? lateReturnPenaltyPerDayBYN, CancellationToken cancellationToken = default)
        {
            return await _carRepository.UpdateCarPriceDataAsync(carId, pricePerDayBYN, lateReturnPenaltyPerDayBYN, cancellationToken);
        }

        public async Task<CarReservationData?> UpdateCarReservationDataAsync(Guid carId, CarReservationStatus? carReservationStatus, int? serviceTimeHours, CancellationToken cancellationToken = default)
        {
            return await _carRepository.UpdateCarReservationDataAsync(carId, carReservationStatus, serviceTimeHours, cancellationToken);
        }
    }
}
