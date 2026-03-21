using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarReservationDataRepository
    {
        public void Add(CarReservationData carReservationData);
        public void Update(Guid CarId, List<RentalPeriod>? occupiedPeriods, CarReservationStatus? carReservationStatus);
        public void AddOccupiedPeriod(Guid CarId, RentalPeriod occupiedPeriod);
        public void DeleteOccupiedPeriod(Guid CarId, RentalPeriod occupiedPeriod);
        public CarReservationData GetById(Guid carId);
    }
}
