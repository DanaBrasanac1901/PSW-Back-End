using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using HospitalLibrary.Core.User;


namespace HospitalLibrary.Core.EmailSender
{

    public class EmailSendService : IEmailSendService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSendService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public bool SendEmail(Message message)
        {
            try
            {
                var emailMessage = CreateEmailMessage(message);

                Send(emailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Hospital", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();



            client.Connect("smtp.gmail.com", _emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

            client.Send(mailMessage);



            client.Disconnect(true);
            client.Dispose();


        }
    }
}
