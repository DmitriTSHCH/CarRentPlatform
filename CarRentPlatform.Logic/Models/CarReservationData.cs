using CarRentPlatform.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum CarReservationStatus { Available, NotReturned, Repair, Blocked, Deleted }
    public class CarReservationData
    {
        public Guid CarId { get; private set; }
        public CarReservationStatus CarReservationStatus { get; private set; }
        public TimeSpan ServiceTime { get; private set; }

        private readonly List<RentalPeriod> _occupiedPeriods = new();

        public CarReservationData()
        {

        }
    }
}
