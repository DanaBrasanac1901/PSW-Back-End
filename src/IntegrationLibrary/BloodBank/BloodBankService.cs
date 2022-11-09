using IntegrationLibrary.Settings;
using MailKit;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Nest;

namespace IntegrationLibrary.BloodBank
{
    public class BloodBankService : IBloodBankService
    {
        private readonly IBloodBankRepository bloodBankRepository;
        private readonly IConfiguration _config;
        public BloodBankService(IBloodBankRepository context, IConfiguration config)
        {
            bloodBankRepository = context;
            _config= config;    
        }


        public  void Create(BloodBank bb)
        {
            bb.Id = Guid.NewGuid();
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            bb.Apikey = Convert.ToBase64String(key);
            bb.Password =  Guid.NewGuid().ToString();
            bb.IsConfirmed = false;
            bloodBankRepository.Create(bb);
           SendEmail(bb.Id);


        }

        public void Delete(Guid id)
        {
            var bloodBank = GetById(id);
            if (bloodBank != null)
            {

                bloodBankRepository.Delete(bloodBank);         }

        }

        public IEnumerable<BloodBank> GetAll()
        {
           return bloodBankRepository.GetAll();
        }

        public BloodBank GetById(Guid id)
        {
           return bloodBankRepository.GetById(id);
           
        }

        

        public BloodBank Update(Guid id,BloodBank bb)
        {
            var bloodBank = GetById(id);
            if (bloodBank != null)
            {
                bloodBank.Username = bb.Username;
                bloodBank.Password = bb.Password;
                bloodBank.Path = bb.Path;
                bloodBankRepository.Update(bloodBank);
                return (bloodBank);
            }
            
            return null;
        }

         public void UpdatePassword(Guid id, string pp)
        {
            var bloodBank = GetById(id);
            bloodBank.Password = pp;
            bloodBank.IsConfirmed = true;
            bloodBankRepository.Update(bloodBank);
        }

        

        Email ConfigureEmail(Guid id)
        {
            var bloodBank = GetById(id);
            Email email = new Email(bloodBank.Email, _config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            return email;

        }

        void SendEmail(Guid id)
        {

            Email emailConf = ConfigureEmail(id);

            string path = id.ToString();
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailConf.From));
            email.To.Add(MailboxAddress.Parse(emailConf.To));
            email.Subject = "Confirm Your registration in our hospital";
            //'/'
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Please" };


            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(emailConf.From, emailConf.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

        }

        void IBloodBankService.SendEmail(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
