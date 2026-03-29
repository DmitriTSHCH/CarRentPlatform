using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class CarModel
    {
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public string Brand { get; private set; }
        public string Model { get; private set; }

        private readonly ModelSpecifications _modelSpecifications;

        public CarModel()
        {

        }
    }
}
