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

        public async Task<CarReservationData?> AddAsync(CarReservationData carReservationData, CancellationToken cancellationToken)
        {
            _dbContext.AddAsync(carReservationData, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(carReservationData.CarId, cancellationToken);
        }

        public async Task<CarReservationData?> UpdateAsync(Guid carId, CarReservationStatus? carReservationStatus, TimeSpan? serviceTime, CancellationToken cancellationToken)
        {
            var builder = _dbContext.CarReservationDatas
                .Where(m => m.CarId == carId);

            if (carReservationStatus != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.CarReservationStatus, carReservationStatus), cancellationToken);
            }

            if (serviceTime != null)
            {
                builder.ExecuteUpdateAsync(r => r.SetProperty(p => p.ServiceTime, serviceTime), cancellationToken);
            }

            return await GetByIdAsync(carId, cancellationToken);
        }

        public async Task<CarReservationData?> GetByIdAsync(Guid carId, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Include(r => r.OccupiedPeriods)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.CarId == carId, cancellationToken);
        }

        public async Task<List<CarReservationData>> GetByFreePeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Where(c => !c
                .OccupiedPeriods
                .Any(p => dateTimeStart < (p.DateTimeEnd + c.ServiceTime) && dateTimeEnd > (p.DateTimeStart - c.ServiceTime)))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<CarReservationData>> GetByOccupiedPeriodAsync(DateTime dateTimeStart, DateTime dateTimeEnd, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Where(c => c
                .OccupiedPeriods
                .Any(p => dateTimeStart < (p.DateTimeEnd + c.ServiceTime) && dateTimeEnd > (p.DateTimeStart - c.ServiceTime)))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<CarReservationData>> GetByStatusAsync(List<CarReservationStatus> carReservationStatuses, CancellationToken cancellationToken)
        {
            return await _dbContext.CarReservationDatas
                .Include(r => r.OccupiedPeriods)
                .AsNoTracking()
                .Where(r => carReservationStatuses.Contains(r.CarReservationStatus))
                .ToListAsync(cancellationToken);
        }
    }
}
