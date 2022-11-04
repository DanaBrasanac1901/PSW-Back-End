using AutoMapper;
using IntegrationLibrary.BloodBank;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using static System.Net.WebRequestMethods;

namespace IntegrationAPI.BBConnection
{


    public class EmailSender
    {

        //    private readonly IEmailService _IEmailService;

        //    public EmailSender(IEmailService IbbService)
        //    {
        //        this._IEmailService = IbbService;

        //    }

        //    public void SendEmail(Guid id)
        //    {

        //        Email emailConf= _IEmailService.ConfigureEmail(id);

        //        string path = id.ToString();
        //        var email = new MimeMessage();
        //        email.From.Add(MailboxAddress.Parse(emailConf.From));
        //        email.To.Add(MailboxAddress.Parse(emailConf.To));
        //        email.Subject = "Confirm Your registration in our hospital";
        //        //'/'
        //        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Please" };


        //        using var smtp = new SmtpClient();
        //        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        //        smtp.Authenticate(emailConf.From, emailConf.Password);
        //        smtp.Send(email);
        //        smtp.Disconnect(true);

        //    }



        //}
    }
}
