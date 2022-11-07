using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood
{
    public interface IBloodSupplyRepository
    {
        IEnumerable<BloodSupply> GetAll();
        BloodSupply GetById(int id);
        void Create(BloodSupply bloodSupply);
        void Update(BloodSupply bloodSupply);
        void Delete(BloodSupply bloodSupply);
    }
}