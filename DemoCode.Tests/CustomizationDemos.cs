using AutoFixture;
using System;
using Xunit;

namespace DemoCode.Tests
{
    public class CustomizationDemos
    {
        [Fact]
        public void DateTimeCustomization()
        {
            Fixture fixture = new Fixture();

            //fixture.Customize(new CurrentDateTimeCustomization()); //current date time
            fixture.Customizations.Add(new CurrentDateTimeGenerator());

            DateTime dateTime1 = fixture.Create<DateTime>();
            DateTime dateTime2 = fixture.Create<DateTime>();
        }

        [Fact]
        public void CustomizePipeline()
        {
            // arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new AirportCodeStringPropertyGenerator());

            var flight = fixture.Create<FlightDetails>();
            var airport = fixture.Create<Airport>();
        }
    }
}
