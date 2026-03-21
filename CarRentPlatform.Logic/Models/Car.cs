using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentPlatform.Logic.Models
{
    public enum CarColor { White, Black, Red, Green, Blue, Yellow, Magenta, Cyan, Gray, LightGray, DarkGray, Silver, Orange, Pink, Brown, Gold, Violet, Lime, Olive, Other }
    public class Car
    {
        public Guid CarId { get; set; }
        public Guid ModelId { get; set; }
        public CarModel CarModel { get; set; }
        public CarColor CarColor { get; set; }
        public CarPriceData CarPriceData { get; set; }
        public CarReservationData CarReservationData { get; set; }
    }
}
