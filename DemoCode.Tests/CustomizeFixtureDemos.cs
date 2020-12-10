using System;
using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class CustomizeFixtureDemos
    {
        [Fact]
        public void SettingTheString()
        {
            // arrange
            var fixture = new Fixture();

            fixture.Inject("LRH");

            var flight = fixture.Create<FlightDetails>();

        }

        [Fact]
        public void SettingValueForCustomType()
        {
            var fixture = new Fixture();

            fixture.Inject(new FlightDetails
            {
                DepartureAirportCode = "PER",
                ArrivalAirportCode = "LHR",
                FlightDuration = TimeSpan.FromHours(10),
                AirlineName = "Awesome Aero"
            });

            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();

        }

        [Fact]
        public void CustomCreationFunction()
        {
            // arrange
            var fixture = new Fixture();

            fixture.Register(() => DateTime.Now.Ticks.ToString());

            var string1 = fixture.Create<string>();
            var string2 = fixture.Create<string>();

        }

        [Fact]
        public void ManuallyFreezingValues()
        {
            // arrange
            var fixture = new Fixture();

            var id = fixture.Create<int>();
            fixture.Inject(id);

            var customerName = fixture.Create<string>();
            fixture.Inject(customerName);

            var sut = fixture.Create<Order>();

            Assert.Equal(id + "-" + customerName, sut.ToString());
        }

        [Fact]
        public void AutoFreezingValues()
        {
            // arrange
            var fixture = new Fixture();

            var id = fixture.Freeze<int>();
            var customerName = fixture.Freeze<string>();

            var sut = fixture.Create<Order>();

            Assert.Equal(id + "-" + customerName, sut.ToString());
        }

        [Fact]
        public void OmitSettingSpecificProperties()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .Without(x => x.ArrivalAirportCode)
                .Without(x => x.DepartureAirportCode)
                .Create();

        }

        [Fact]
        public void OmitAllProperties()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .OmitAutoProperties()
                .Create();
        }

        [Fact]
        public void CustomizeBuilding()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .With(x => x.ArrivalAirportCode, "LAX")
                .With(x => x.DepartureAirportCode, "LHR")
                .Create();
        }

        [Fact]
        public void CustomizeBuildingWithAction()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .With(x => x.ArrivalAirportCode, "LAX")
                .With(x => x.DepartureAirportCode, "LHR")
                .Without(x => x.MealOptions)
                .Do(x => x.MealOptions.Add("Chicken"))
                .Do(x => x.MealOptions.Add("Fish"))
                .Create();
        }

        [Fact]
        public void CustomizeBuildingForAllTypesFixture()
        {
            // arrange
            var fixture = new Fixture();

            //no .Create() is required here
            fixture.Customize<FlightDetails>(fd =>
                fd.With(x => x.ArrivalAirportCode, "LAX")
                  .With(x => x.DepartureAirportCode, "LHR")
                  .Without(x => x.MealOptions)
                  .Do(x => x.MealOptions.Add("Chicken"))
                  .Do(x => x.MealOptions.Add("Fish")));

            //both flight1 and flight2 are the same
            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();
        }
    }
}
