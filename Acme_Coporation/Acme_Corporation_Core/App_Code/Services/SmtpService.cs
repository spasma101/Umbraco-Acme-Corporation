using System.Net.Mail;
using Acme_Corporation_Core.App_Code.Helpers;

namespace Acme_Corporation_Core.App_Code.Services
{
    public class SmtpService
    {
        private readonly bool _isTest;
        private readonly string _testRecipient;

        public SmtpService()
            : this(
                AppSettings.IsTest,
                AppSettings.TestingEmailRecipent
                )
        { }

        public SmtpService(bool isTest, string testRecipient)
        {
            _isTest = isTest;
            _testRecipient = testRecipient;
        }

        public void Send(MailMessage message)
        {
            if (_isTest)
            {
                message.To.Clear();
                message.To.Add(_testRecipient);
                message.Priority = MailPriority.High;

            }
            new SmtpClient().Send(message);
        }
    }
}