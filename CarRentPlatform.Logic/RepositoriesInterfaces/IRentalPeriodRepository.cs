using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IRentalPeriodRepository
    {
        public void Add(RentalPeriod rentalPeriod);
        public void Update(Guid periodId, DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId, Guid? userId, PeriodStatus? periodStatus, decimal? RentalPrice);
        public RentalPeriod GetById(Guid periodId);
        public List<RentalPeriod> GetByCarId(Guid carId);
        public List<RentalPeriod> GetByUserId(Guid userId);
    }
}
