using System;
using System.Collections.Generic;
using System.Text;
using CarRentPlatform.Logic.Models;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarRepository
    {
        public void Add(Car car);
        public void Update(Guid CarId, Guid? modelId, CarModel? CarModel, CarColor? carColor, CarPriceData? carPriceData, CarReservationData? carReservationData );
        public Car GetById(Guid carId);
        public List<Car> GetByFilter(string? brand, string? model, CarColor? carColor);
        public List<Car> GetByFilter(string? brand, string? model, CarColor? carColor, CarType? carType, Fuel? fuel, int? numberOfSeatsWithDriver, float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km, float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm, DateTime dateTimeStartNewPeriod, DateTime dateTimeEndNewPeriod, decimal pricePerDay);
    }
}
