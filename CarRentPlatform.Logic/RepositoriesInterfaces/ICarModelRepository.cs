using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarModelRepository
    {
        public CarModel Add(CarModel carModel);
        public CarModel Update(Guid modelId, string? brand, string? model);
        public CarModel GetById(Guid modelId);
        public List<CarModel> GetByFilter(List<string>? brands, List<string>? models);
    }
}
