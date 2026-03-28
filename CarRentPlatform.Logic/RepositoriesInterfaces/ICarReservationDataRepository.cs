using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarReservationDataRepository
    {
        public Task<CarReservationData?> AddAsync(CarReservationData carReservationData, CancellationToken cancellationToken = default);
        public Task<CarReservationData?> UpdateAsync(Guid carId, CarReservationStatus? carReservationStatus, 
                                         TimeSpan? serviceTime, CancellationToken cancellationToken = default);
        public Task<CarReservationData?> GetByIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<List<CarReservationData>> GetByFreePeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken = default);
        public Task<List<CarReservationData>> GetByOccupiedPeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken = default);
        public Task<List<CarReservationData>> GetByStatusAsync(List<CarReservationStatus> carReservationStatuses, CancellationToken cancellationToken = default);
    }
}
