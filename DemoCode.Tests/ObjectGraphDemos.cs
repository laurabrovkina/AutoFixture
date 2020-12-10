using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class ObjectGraphDemos
    {
        [Fact]
        public void AutoCreation()
        {
            // arrange
            Fixture fixture = new Fixture();

            var message = fixture.Create<Order>();

        }
    }
}
