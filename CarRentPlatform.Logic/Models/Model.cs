using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class Model
    {
        public Guid ModelId { get; private set; } = Guid.NewGuid();
        public string Brand { get; private set; }
        public string ModelName { get; private set; }

        public ModelSpecifications ModelSpecifications { get; private set; }

        public Model()
        {

        }
    }
}
