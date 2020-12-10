using System.Net.Mail;
using AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class EmailAddressDemos
    {
        [Fact]
        public void EmailGuid()
        {
            // arrange
            Fixture fixture = new Fixture();

            //var localPart = fixture.Create<EmailAddressLocalPart>().LocalPart;
            //var domain = fixture.Create<DomainName>().Domain;

            //var fullAddress = $"{localPart}@{domain}";

            var sut = new EmailMessageV1(fixture.Create<MailAddress>().Address,
                fixture.Create<string>(),
                fixture.Create<bool>());
        }
    }
}
