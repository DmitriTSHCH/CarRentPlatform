using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarModelRepository
    {
        public Task<CarModel?> AddAsync(CarModel carModel, CancellationToken cancellationToken = default);
        public Task<CarModel?> UpdateAsync(Guid modelId, string? brand, string? model, CancellationToken cancellationToken = default);
        public Task<CarModel?> GetByIdAsync(Guid modelId, CancellationToken cancellationToken = default);
        public Task<List<CarModel>> GetByFilterAsync(List<string>? brands, List<string>? models, CancellationToken cancellationToken = default);
    }
}
