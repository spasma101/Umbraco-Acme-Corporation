using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;
using log4net;
using RazorEngine;
using RazorEngine.Templating;
using Acme_Corporation_Core.App_Code.Helpers;

// For extension methods.

namespace Acme_Corporation_Core.App_Code.Services
{
    public class SendEmailService
    {
        protected ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void SendEmail<T>(List<string> to, string templateFilePath, T model, string subject)
        {
            Logger.Info(string.Format("STARTED: SendEmailService.SendEmail"));

            var emailTemplate = FileHelper.LoadFileContents(templateFilePath);

	        var templateRandomName = FormHelperMethods.RandomString(4);

	        string emailBody = Engine.Razor.RunCompile(emailTemplate, templateRandomName, null, model);

			var message = new MailMessage
            {
                Body = emailBody,
                IsBodyHtml = true,
                Subject = subject
            };

            foreach (var address in to)
            {
                message.To.Add(address);
            }

            new SmtpService().Send(message);

            Logger.Info(string.Format("COMPLETED: SendEmailService.SendEmail"));
        }
    }
}
