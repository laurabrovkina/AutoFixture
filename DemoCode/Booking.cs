using System.Collections.Generic;

namespace DemoCode
{
    public class Booking
    {
        public string BookingReference { get; set; }
        public string CustomerName { get; set; }
        public List<FlightDetailsV2> Legs { get; set; } = new List<FlightDetailsV2>();
    }
}
