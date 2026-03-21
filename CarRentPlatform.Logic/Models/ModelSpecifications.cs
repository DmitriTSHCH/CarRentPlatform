using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum Fuel { gasoline, diesel, electricity }
    public enum TankUnit { liter, kWh }
    public enum CarType { Sedan, Hatchback, Liftback, StationWagon, Coupe, SUV, Crossover, Pickup, Minivan, Van, Convertible, Limousine, MuscleCar, Other }
    public class ModelSpecifications
    {
        public Guid ModelId { get; set; }
        public Fuel Fuel { get; set; }

        [Range(1, int.MaxValue)]
        public int NumberOfSeatsWithDriver { get; set; }

        [Range(0.0, double.MaxValue)]
        public float TrunkVoluem { get; set; }

        [Range(0.0, double.MaxValue)]
        public float TankCapacity { get; set; }
        public TankUnit TankUnit => Fuel == Fuel.electricity ? TankUnit.kWh : TankUnit.liter ;

        [Range(0.0, double.MaxValue)]
        public float CityConsumptionPer100km { get; set; }

        [Range(0.0, double.MaxValue)]
        public float HighwayConsumptionPer100km { get; set; }

        [Range(0.0, double.MaxValue)]
        public float CityRangeKm { get; set; }

        [Range(0.0, double.MaxValue)]
        public float HighwayRangeKm { get; set; }
        public CarType CarType { get; set; }
    }
}
