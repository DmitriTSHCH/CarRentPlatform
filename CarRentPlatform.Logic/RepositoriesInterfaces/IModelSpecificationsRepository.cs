using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.RepositoriesInterfaces
{
    public interface IModelSpecificationsRepository
    {
        public void Add(ModelSpecifications modelSpecifications);
        public void Update(Guid ModelId, Fuel? fuel, int? numberOfSeatsWithDriver, float? trunkVoluem, float? tankCapacity, float? cityConsumptionPer100km, float? highwayConsumptionPer100km, float? cityRangeKm, float? highwayRangeKm, CarType carType);
        public Car GetById(Guid ModelId);
    }
}
