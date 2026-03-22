using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum CarReservationStatus { Available, NotReturned, Repair, Blocked, Deleted }
    public class CarReservationData
    {
        public Guid CarId { get; set; }
        public List<RentalPeriod> OccupiedPeriods { get; set; } = new();
        public CarReservationStatus CarReservationStatus { get; set; }
        public TimeSpan ServiceTime { get; set; }
    }
}
