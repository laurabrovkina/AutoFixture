using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Moq;

namespace DemoCode.Tests
{
    public class EmailMessageBufferShould
    {
        [Fact]
        public void AddMessageToBuffer()
        {
            var fixture = new Fixture();
            var mockGateway = new Mock<EmailGateway.IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway.Object);

            sut.Add(fixture.Create<EmailMessage>());

            Assert.Equal(1, sut.UnsentMessagesCount);
        }


        [Fact]
        public void RemoveMessageFromBufferWhenSent()
        {
            var fixture = new Fixture();
            var mockGateway = new Mock<EmailGateway.IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway.Object);

            sut.Add(fixture.Create<EmailMessage>());

            sut.SendAll();

            Assert.Equal(0, sut.UnsentMessagesCount);
        }


        [Fact]
        public void SendOnlySpecifiedNumberOfMessages()
        {
            var fixture = new Fixture();
            var mockGateway = new Mock<EmailGateway.IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway.Object);

            sut.Add(fixture.Create<EmailMessage>());
            sut.Add(fixture.Create<EmailMessage>());
            sut.Add(fixture.Create<EmailMessage>());

            sut.SendLimited(2);

            Assert.Equal(1, sut.UnsentMessagesCount);
        }

        [Fact]
        public void SendEmailGateway_Manual_Moq()
        {
            var fixture = new Fixture();
            var mockGateway = new Mock<EmailGateway.IEmailGateway>();

            var sut = new EmailMessageBuffer(mockGateway.Object);

            sut.Add(fixture.Create<EmailMessage>());

            sut.SendAll();

            mockGateway.Verify(x =>x.Send(It.IsAny<EmailMessage>()), Times.Once);
        }


        [Fact]
        public void SendEmailGateway_AutoMoq()
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var mockGateway = fixture.Freeze<Mock<EmailGateway.IEmailGateway>>();

            var sut = fixture.Create<EmailMessageBuffer>();

            sut.Add(fixture.Create<EmailMessage>());

            sut.SendAll();

            //no reference to the mock IEmailGateway that was automatically provided
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once);

        }

        [Theory]
        [AutoMoqData]
        public void SendEmailGateway_AutoMoq_v2(EmailMessage message,
            [Frozen] Mock<EmailGateway.IEmailGateway> mockGateway,
            EmailMessageBuffer sut)
        {
            sut.Add(message);

            sut.SendAll();

            //no reference to the mock IEmailGateway that was automatically provided
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once);
        }
    }
}