using System;
using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class GuidEnumDemos
    {
        [Fact]
        public void EmailGuid()
        {
            // arrange
            Fixture fixture = new Fixture();
            var sut = new EmailMessageV1(fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<bool>());

            // act
            sut.Id = fixture.Create<Guid>();

            // etc.
        }

        [Fact]
        public void Enum()
        {
            // arrange
            Fixture fixture = new Fixture();
            var sut = new EmailMessageV1(fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<bool>());

            // act
            sut.Id = fixture.Create<Guid>();

            sut.MessageType = fixture.Create<EmailMessageType>();

            // etc.
        }
    }
}
