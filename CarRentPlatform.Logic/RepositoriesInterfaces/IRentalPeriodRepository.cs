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
        public List<RentalPeriod> GetByOccupiedPeriod(DateTime? beforeDateTime, DateTime? afterDateTime);
        public List<RentalPeriod> GetByFilter( DateTime? beforeDateTime, DateTime? afterDateTime, Guid? carId, Guid? userId, List<PeriodStatus>? periodStatuses, decimal? minRentalPriceBYN, decimal? maxRentalPriceBYN);
    }
}
