using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public class CarPriceData
    {
        public Guid CarId { get; set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal PricePerDayBYN { get; set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal LateReturnPenaltyPerDayBYN { get; set; }
    }
}
