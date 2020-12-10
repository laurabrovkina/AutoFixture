using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class AnnotationDemos
    {
        [Fact]
        public void AutoCreation()
        {
            // arrange
            Fixture fixture = new Fixture();

            var player = fixture.Create<PlayerCharacter>();

        }
    }
}
