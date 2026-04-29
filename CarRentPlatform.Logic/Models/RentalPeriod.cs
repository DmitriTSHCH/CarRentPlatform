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
        public Guid PeriodId { get; private set; } = Guid.NewGuid();
        public DateTime DateTimeStart { get; private set; }
        public DateTime DateTimeEnd { get; private set; }
        public Guid CarId { get; private set; }
        public Guid UserId { get; private set; }
        public PeriodStatus PeriodStatus { get; private set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal RentalPriceBYN { get; private set; }

        public DateTime DateTimeCreation { get; private set; } = DateTime.UtcNow;

        public RentalPeriod()
        {

        }

        public RentalPeriod(DateTime dateTimeStart, DateTime dateTimeEnd, Guid carId, Guid userId, decimal rentalPriceBYN)
        {
            DateTimeStart = dateTimeEnd;
            DateTimeEnd = dateTimeStart;
            CarId = carId;
            UserId = userId;
            RentalPriceBYN = rentalPriceBYN;
            PeriodStatus = PeriodStatus.waitPayment;
        }
    }
}
