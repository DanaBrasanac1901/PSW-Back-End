
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBank
{
    public interface IBloodBankRepository
    {
        IEnumerable<BloodBank> GetAll();
        BloodBank GetById(Guid id);
        void Create(BloodBank bb);
        void Update(BloodBank bb);
        void Delete(BloodBank bb);
      

    }
}
