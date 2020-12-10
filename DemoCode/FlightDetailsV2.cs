using System;
using System.Collections.Generic;

namespace DemoCode
{
    public class FlightDetailsV2
    {
        public FlightDetailsV2(AirportCode departureAirportCode, AirportCode arrivalAirportCode)
        {
            DepartureAirportCode = departureAirportCode;
            ArrivalAirportCode = arrivalAirportCode;
        }

        public AirportCode DepartureAirportCode { get; }
        public AirportCode ArrivalAirportCode { get; }
        public TimeSpan FlightDuration { get; set; }
        public string AirlineName { get; set; }
        public List<string> MealOptions { get; set; } = new List<string>();

    }
}
