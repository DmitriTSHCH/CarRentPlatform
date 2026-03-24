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

        public CarModel Add(CarModel carModel)
        {
            _dbContext.Add(carModel);
            _dbContext.SaveChanges();

            return GetById(carModel.ModelId);
        }

        public List<CarModel> GetByFilter(List<string>? brands, List<string>? models)
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
                
            return builder.ToList();
        }

        public CarModel GetById(Guid modelId)
        {
            return _dbContext.CarModels
                .Include(m => m.ModelSpecifications)
                .AsNoTracking()
                .FirstOrDefault(m => m.ModelId == modelId);
        }

        public CarModel Update(Guid modelId, string? brand, string? model )
        {
            var builder = _dbContext.CarModels
                .Where(m => m.ModelId == modelId);

            if (brand != null)
            {
                builder.ExecuteUpdate(m => m.SetProperty(p => p.Brand, brand));
            }

            if (model != null)
            {
                builder.ExecuteUpdate(m => m.SetProperty(p => p.Model, model));
            }

            return GetById(modelId);
        }
    }
}
