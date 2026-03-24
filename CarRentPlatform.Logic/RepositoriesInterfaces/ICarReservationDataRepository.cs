using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarReservationDataRepository
    {
        public CarReservationData Add(CarReservationData carReservationData);
        public CarReservationData Update(Guid carId, CarReservationStatus? carReservationStatus, TimeSpan? serviceTime);
        public CarReservationData GetById(Guid carId);
        public List<CarReservationData> GetByFreePeriod(DateTime dateTimeStart, DateTime dateTimeEnd);
        public List<CarReservationData> GetByOccupiedPeriod(DateTime dateTimeStart, DateTime dateTimeEnd);
        public List<CarReservationData> GetByStatus(List<CarReservationStatus> carReservationStatuses);
    }
}
