using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;

namespace Acme_Corporation_Core.App_Code.Services
{
    public class Email
    {
        public static MailMessage GenerateMessage(List<string> to, string from, string displayName, string subject, object bodyObject, string urlAuthority, string emailHeader)
        {
            var message = new MailMessage
            {
                Subject = subject,
                From = new MailAddress(from, displayName)
            };
            foreach (var address in to)
            {
                message.To.Add(address);
            }

            StringBuilder messageBody = new StringBuilder();
            messageBody.Append(string.Format("<h3>{0}</h3>{1}", emailHeader, Environment.NewLine));
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(bodyObject))
            {
                string name = string.Format("{0}:", descriptor.Name);
                object value = descriptor.GetValue(bodyObject);
                messageBody.Append(string.Format("<b>{0}</b> {1}<br />", name.PadRight(25), value));
            }
            messageBody.Append(String.Format("<br />Sent from {0}", urlAuthority));

            message.Body = messageBody.ToString();
            message.IsBodyHtml = true;

            return message;
        }

    }
}
