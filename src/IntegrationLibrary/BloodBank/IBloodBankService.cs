using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBank
{
    public interface IBloodBankService
    {
       
       
            IEnumerable<BloodBank> GetAll();
            BloodBank GetById(Guid id);
            void Create(BloodBank bb);
            BloodBank Update(Guid id,BloodBank bb);
            void Delete(Guid bb);

            void UpdatePassword(Guid id, string pp);

           void SendEmail(Guid id);


    }
}

