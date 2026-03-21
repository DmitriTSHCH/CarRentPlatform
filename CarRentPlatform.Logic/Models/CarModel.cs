using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class CarModel
    {
        public Guid ModelId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ModelSpecifications ModelSpecifications { get; set; }
    }
}
