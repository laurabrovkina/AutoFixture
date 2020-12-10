using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class EmailMessageBufferV1
    {
        public List<EmailMessageV1> Emails { get; private set; } = new List<EmailMessageV1>();

        public void SendAll()
        {
            foreach (var email in Emails)
            {
                // Send email
            }
        }

        public void Add(EmailMessageV1 message)
        {
            Emails.Add(message);
        }
    }
}
