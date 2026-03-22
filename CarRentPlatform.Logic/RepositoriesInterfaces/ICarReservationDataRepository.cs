using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarReservationDataRepository
    {
        public CarReservationData Add(CarReservationData carReservationData);
        public CarReservationData UpdateStatus(Guid CarId, CarReservationStatus carReservationStatus);
        public CarReservationData AddOccupiedPeriod(Guid CarId, RentalPeriod occupiedPeriod);
        public CarReservationData DeleteOccupiedPeriod(Guid CarId, RentalPeriod occupiedPeriod);
        public CarReservationData GetById(Guid carId);
        public List<CarReservationData> GetByFreePeriod(DateTime dateTimeStart, DateTime dateTimeEnd);
        public List<CarReservationData> GetByOccupiedPeriod(DateTime dateTimeStart, DateTime dateTimeEnd);
        public List<CarReservationData> GetByStatus(List<CarReservationStatus> carReservationStatuses);
    }
}
