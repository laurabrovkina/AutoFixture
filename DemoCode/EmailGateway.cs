using System.Diagnostics;

namespace DemoCode
{
    public class EmailGateway : EmailGateway.IEmailGateway
    {

        public interface IEmailGateway
        {
            void Send(EmailMessage message);
        }

        public void Send(EmailMessage message)
        {
            // simulate sending email
            Debug.WriteLine("Sending email to: " + message.ToAddress);
        }
    }
}
