using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class RentalPeriodRepository : IRentalPeriodRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public RentalPeriodRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RentalPeriod Add(RentalPeriod rentalPeriod)
        {
            _dbContext.Add(rentalPeriod);
            _dbContext.SaveChanges();

            return GetById(rentalPeriod.PeriodId);
        }

        public List<RentalPeriod> GetByCarId(Guid carId)
        {
            return _dbContext.RentalPeriods
                .AsNoTracking()
                .Where(r => r.CarId == carId)
                .ToList();
        }

        public List<RentalPeriod> GetByFilter(DateTime? beforeDateTime, DateTime? afterDateTime, Guid? carId, Guid? userId, List<PeriodStatus>? periodStatuses, decimal? minRentalPriceBYN, decimal? maxRentalPriceBYN)
        {
            var builder = _dbContext.RentalPeriods
                .AsNoTracking();

            if (beforeDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeEnd <= beforeDateTime);
            }

            if (afterDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeStart >= afterDateTime);
            }

            if (carId != null)
            {
                builder = builder.Where(c => c.CarId == carId);
            }

            if (userId != null)
            {
                builder = builder.Where(c => c.UserId == userId);
            }

            if (periodStatuses != null)
            {
                builder = builder.Where(c => periodStatuses.Contains(c.PeriodStatus));
            }

            if (minRentalPriceBYN != null)
            {
                builder = builder.Where(c => c.RentalPriceBYN >= minRentalPriceBYN);
            }

            if (maxRentalPriceBYN != null)
            {
                builder = builder.Where(c => c.RentalPriceBYN <= maxRentalPriceBYN);
            }

            return builder.ToList();
        }

        public RentalPeriod GetById(Guid periodId)
        {
            return _dbContext.RentalPeriods
                .AsNoTracking()
                .FirstOrDefault(r => r.PeriodId == periodId);
        }

        public List<RentalPeriod> GetByOccupiedPeriod(DateTime? beforeDateTime, DateTime? afterDateTime)
        {
            var builder = _dbContext.RentalPeriods
                .AsNoTracking();

            if (beforeDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeEnd <= beforeDateTime);
            }

            if (afterDateTime != null)
            {
                builder = builder.Where(c => c.DateTimeStart >= afterDateTime);
            }

            return builder.ToList();
        }

        public List<RentalPeriod> GetByUserId(Guid userId)
        {
            return _dbContext.RentalPeriods
                .AsNoTracking()
                .Where(r => r.UserId == userId)
                .ToList();
        }

        public RentalPeriod Update(Guid periodId, DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId,
                                   Guid? userId, PeriodStatus? periodStatus, decimal? rentalPriceBYN)
        {
            var builder = _dbContext.RentalPeriods
                .Where(m => m.PeriodId == periodId);

            if (dateTimeStart != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.DateTimeStart, dateTimeStart));
            }

            if (dateTimeEnd != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.DateTimeEnd, dateTimeEnd));
            }

            if (carId != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.CarId, carId));
            }

            if (userId != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.UserId, userId));
            }

            if (periodStatus != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.PeriodStatus, periodStatus));
            }

            if (rentalPriceBYN != null)
            {
                builder.ExecuteUpdate(r => r.SetProperty(p => p.RentalPriceBYN, rentalPriceBYN));
            }

            return GetById(periodId);
        }
    }
}
