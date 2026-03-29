using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum CarColor { White, Black, Red, Green, Blue, Yellow, Magenta, Cyan, Gray, LightGray, DarkGray, Silver, Orange, Pink, Brown, Gold, Violet, Lime, Olive, Other }
    public class Car
    {
        public Guid CarId { get; private set; } = Guid.NewGuid();
        public Guid ModelId { get; private set; }
        public CarColor CarColor { get; private set; }

        private readonly CarModel _carModel;
        private readonly CarPriceData _carPriceData;
        private readonly CarReservationData _carReservationData;
        private readonly DateTime _dateTimeCreation = DateTime.UtcNow;

        public Car()
        {
        
        }
    }
}
