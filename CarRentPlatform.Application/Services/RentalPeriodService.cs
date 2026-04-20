using CarRentPlatform.Application.Interfaces;
using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentPlatform.Application.Services
{
    public class RentalPeriodService : IRentalPeriodService
    {
        private readonly IRentalPeriodRepository _rentalPeriodRepository;

        public RentalPeriodService(IRentalPeriodRepository rentalPeriodRepository)
        {
            _rentalPeriodRepository = rentalPeriodRepository;
        }

        public async Task<RentalPeriod?> AddAsync(RentalPeriod rentalPeriod, CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.AddAsync(rentalPeriod, cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByCarIdAsync(Guid carId, CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.GetByCarIdAsync(carId, cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByFilterAsync(DateTime? beforeDateTime, DateTime? afterDateTime,
                                                               Guid? carId, Guid? userId,
                                                               List<PeriodStatus>? periodStatuses,
                                                               decimal? minRentalPriceBYN, decimal? maxRentalPriceBYN,
                                                               CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.GetByFilterAsync(beforeDateTime, afterDateTime, carId, userId, periodStatuses, minRentalPriceBYN, maxRentalPriceBYN, cancellationToken);
        }

        public async Task<RentalPeriod?> GetByIdAsync(Guid periodId, CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.GetByIdAsync(periodId, cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByOccupiedPeriodAsync(DateTime? beforeDateTime, DateTime? afterDateTime, CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.GetByOccupiedPeriodAsync(beforeDateTime, afterDateTime, cancellationToken);
        }

        public async Task<List<RentalPeriod>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.GetByUserIdAsync(userId, cancellationToken);
        }

        public async Task<RentalPeriod?> UpdateAsync(Guid periodId, DateTime? dateTimeStart, DateTime? dateTimeEnd, Guid? carId, Guid? userId, PeriodStatus? periodStatus, decimal? rentalPriceBYN, CancellationToken cancellationToken = default)
        {
            return await _rentalPeriodRepository.UpdateAsync(periodId, dateTimeStart, dateTimeEnd, carId, userId, periodStatus, rentalPriceBYN, cancellationToken);
        }
    }
}
