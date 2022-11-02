using IntegrationLibrary.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBank
{
    public class BloodBankService : IBloodBankService, IEmailService
    {
        private readonly IBloodBankRepository bloodBankRepository;
        private readonly IConfiguration _config;
        public BloodBankService(IBloodBankRepository context, IConfiguration config)
        {
            bloodBankRepository = context;
            _config= config;    
        }


        public void Create(BloodBank bb)
        {
            bb.Id = Guid.NewGuid();
            bb.Apikey = "";
            bb.Password = "";
            bloodBankRepository.Create(bb);
            
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
            bloodBankRepository.Update(bloodBank);
        }

        Email IEmailService.ConfigureEmail(Guid id)
        {
            
            var bloodBank = GetById(id);
            Email email = new Email(bloodBank.Email,_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            return email;

        }
    }
}
