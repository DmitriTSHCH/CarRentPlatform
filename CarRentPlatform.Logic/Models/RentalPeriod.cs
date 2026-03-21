using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum PeriodStatus { waitPayment, active, canceled, finished }
    public class RentalPeriod
    {
        public Guid PeriodId { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public PeriodStatus PeriodStatus { get; set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal RentalPriceBYN { get; set; }
    }
}
