using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class StringDemos
    {
        [Fact]
        public void BasicStrings()
        {
            var fixture = new Fixture();
            var sut = new NameJoiner();

            var firstName = fixture.Create("First_");
            var lastName = fixture.Create("Last_");

            var result = sut.Join(firstName, lastName);

            Assert.Equal(firstName + ' ' + lastName, result);

        }
    }
}
