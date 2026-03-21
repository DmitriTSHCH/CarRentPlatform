using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface ICarModelRepository
    {
        public void Add(CarModel carModel);
        public void Update(Guid ModelId, string? brand, string? model, ModelSpecifications? modelSpecifications);
        public Car GetById(Guid ModelId);
        public List<Car> GetByFilter(string? brand, string? model);
    }
}
