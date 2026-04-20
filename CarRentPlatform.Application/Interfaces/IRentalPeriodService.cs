using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentPlatform.Application.Interfaces
{
    public interface IRentalPeriodService
    {
        public Task<RentalPeriod?> AddAsync(RentalPeriod rentalPeriod, CancellationToken cancellationToken = default);
        public Task<RentalPeriod?> UpdateAsync(Guid periodId, DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId,
                                         Guid? userId, PeriodStatus? periodStatus, decimal? rentalPriceBYN,
                                         CancellationToken cancellationToken = default);
        public Task<RentalPeriod?> GetByIdAsync(Guid periodId, CancellationToken cancellationToken = default);
        public Task<List<RentalPeriod>> GetByCarIdAsync(Guid carId, CancellationToken cancellationToken = default);
        public Task<List<RentalPeriod>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<List<RentalPeriod>> GetByOccupiedPeriodAsync(DateTime? beforeDateTime, DateTime? afterDateTime,
                                                            CancellationToken cancellationToken = default);
        public Task<List<RentalPeriod>> GetByFilterAsync(DateTime? beforeDateTime, DateTime? afterDateTime, Guid? carId,
                                                    Guid? userId, List<PeriodStatus>? periodStatuses,
                                                    decimal? minRentalPriceBYN, decimal? maxRentalPriceBYN,
                                                    CancellationToken cancellationToken = default);
    }
}
