using CarRentPlatform.Logic.Models;
using CarRentPlatform.Logic.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Persistence.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly CarRentPlatformDbContext _dbContext;

        public CarModelRepository(CarRentPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarModel?> AddAsync(CarModel carModel, CancellationToken cancellationToken = default)
        {
            _dbContext.AddAsync(carModel, cancellationToken);
            _dbContext.SaveChangesAsync(cancellationToken);

            return await GetByIdAsync(carModel.ModelId, cancellationToken);
        }

        public async Task<List<CarModel>> GetByFilterAsync(List<string>? brands, List<string>? models, CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarModels
                .AsNoTracking();

            if (brands != null)
            {
                builder = builder.Where(m => brands.Contains(m.Brand));
            }

            if (models != null)
            {
                builder = builder.Where(m => models.Contains(m.Model));
            }
                
            return await builder.ToListAsync(cancellationToken);
        }

        public async Task<CarModel?> GetByIdAsync(Guid modelId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.CarModels
                .Include(m => m.ModelSpecifications)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ModelId == modelId, cancellationToken);
        }

        public async Task<CarModel?> UpdateAsync(Guid modelId, string? brand, string? model, CancellationToken cancellationToken = default)
        {
            var builder = _dbContext.CarModels
                .Where(m => m.ModelId == modelId);

            if (brand != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.Brand, brand), cancellationToken);
            }

            if (model != null)
            {
                builder.ExecuteUpdateAsync(m => m.SetProperty(p => p.Model, model), cancellationToken);
            }

            return await GetByIdAsync(modelId, cancellationToken);
        }
    }
}
