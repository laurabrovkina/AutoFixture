using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class CustomTypeDemos
    {
        [Fact]
        public void AutoCreation()
        {
            // arrange
            var sut = new EmailMessageBufferV1();
            Fixture fixture = new Fixture();
            
            var message = fixture.Create<EmailMessageV1>();

            // act
            sut.Add(message);
            
            // assert
            Assert.Single(sut.Emails);
        }
    }
}
