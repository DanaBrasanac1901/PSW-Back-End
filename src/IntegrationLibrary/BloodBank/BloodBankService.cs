using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBank
{
    internal class BloodBankService : IBloodBankService, IEmailService
    {
        public void SendEmail(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
