using AutoMapper;
using IntegrationLibrary.BloodBank;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;

namespace IntegrationAPI.BBConnection
{

    
    public class EmailSender 
    {

        private readonly IEmailService _IEmailService;

        public EmailSender(IEmailService IbbService)
        {
            this._IEmailService = IbbService;

        }

        public void SendEmail(Guid id)
        {

            Email emailConf= _IEmailService.ConfigureEmail(id);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailConf.From));
            email.To.Add(MailboxAddress.Parse(emailConf.To));
            email.Subject = "Confirm Your registration in our hospital";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { };
        }
        
           
        
    }
}
