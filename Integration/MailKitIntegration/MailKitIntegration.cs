using Core.DataTypes;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;

namespace Integration.MailKitIntegration
{
    public class MailKitIntegration : IMailKitIntegration
    {
        private readonly IConfiguration _configuration;
        public MailKitIntegration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async void SendEmail(Email mail, string reply)
        {
            SendEmail(mail, _configuration.GetSection("Mail").GetSection("SmtpServer").Value, 25, _configuration.GetSection("Mail").GetSection("EmailUser").Value, _configuration.GetSection("Mail").GetSection("EmailPassword").Value, reply);
        }

        public void SendEmail(Email mail, string smtpServer, int smtpPort, string smtpUser, string smtpPassword, string reply)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(mail.From.Name,
            string.IsNullOrWhiteSpace(mail.From.Email) ? "info@flexiblelms.com" : mail.From.Email);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(mail.To.Name, mail.To.Email);
            message.To.Add(to);
            if (!string.IsNullOrEmpty(reply))
            {
                message.ReplyTo.Add(new MailboxAddress(reply, reply));
            }


            message.Subject = mail.Subject;
            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = mail.EmailBody.HtmlBody,
                TextBody = mail.EmailBody.PlainTextBody
            };
            foreach (string file in mail.Attachment)
            {
                bodyBuilder.Attachments.Add(file);
            }
            message.Body = bodyBuilder.ToMessageBody();



            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.None);
                client.Authenticate(smtpUser, smtpPassword);
                client.Send(message);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
