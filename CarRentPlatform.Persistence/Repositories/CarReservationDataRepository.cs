using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class CarReservationDataRepository : ICarReservationDataRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public CarReservationDataRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CarReservationData Add(CarReservationData carReservationData)
        {
            _dbContext.Add(carReservationData);
            _dbContext.SaveChanges();

            return GetById(carReservationData.CarId);
        }

        public CarReservationData Update(Guid carId, CarReservationStatus? carReservationStatus, TimeSpan? serviceTime)
        {
            var builder = _dbContext.CarReservationDatas
                .Where(m => m.CarId == carId);

            if (carReservationStatus != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.CarReservationStatus, carReservationStatus));
            }

            if (serviceTime != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.ServiceTime, serviceTime));
            }

            return GetById(carId);
        }

        public CarReservationData GetById(Guid carId)
        {
            return _dbContext.CarReservationDatas
                .Include(r => r.OccupiedPeriods)
                .AsNoTracking()
                .FirstOrDefault(r => r.CarId == carId);
        }

        public List<CarReservationData> GetByFreePeriod(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            return _dbContext.CarReservationDatas
                .Where(c => !c
                .OccupiedPeriods
                .Any(p => dateTimeStart < (p.DateTimeEnd + c.ServiceTime) && dateTimeEnd > (p.DateTimeStart - c.ServiceTime)))
                .ToList();
        }

        public List<CarReservationData> GetByOccupiedPeriod(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            return _dbContext.CarReservationDatas
                .Where(c => c
                .OccupiedPeriods
                .Any(p => dateTimeStart < (p.DateTimeEnd + c.ServiceTime) && dateTimeEnd > (p.DateTimeStart - c.ServiceTime)))
                .ToList();
        }

        public List<CarReservationData> GetByStatus(List<CarReservationStatus> carReservationStatuses)
        {
            return _dbContext.CarReservationDatas
                .Include(r => r.OccupiedPeriods)
                .AsNoTracking()
                .Where(r => carReservationStatuses.Contains(r.CarReservationStatus))
                .ToList();
        }
    }
}
