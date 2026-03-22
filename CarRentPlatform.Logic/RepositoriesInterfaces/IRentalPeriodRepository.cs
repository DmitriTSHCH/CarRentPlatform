using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IRentalPeriodRepository
    {
        public RentalPeriod Add(RentalPeriod rentalPeriod);
        public RentalPeriod Update(Guid periodId, DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId, Guid? userId, PeriodStatus? periodStatus, decimal? rentalPriceBYN);
        public RentalPeriod GetById(Guid periodId);
        public List<RentalPeriod> GetByCarId(Guid carId);
        public List<RentalPeriod> GetByUserId(Guid userId);
        public List<RentalPeriod> GetByOccupiedPeriod(DateTime dateTimeStart, DateTime dateTimeEnd);
        public List<RentalPeriod> GetByFilter( DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId, Guid? userId, List<PeriodStatus>? periodStatuses, decimal? minRentalPriceBYN, decimal? maxRentalPriceBYN);
    }
}
