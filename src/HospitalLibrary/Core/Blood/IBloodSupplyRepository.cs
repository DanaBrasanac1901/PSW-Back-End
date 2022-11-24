using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood
{
    public interface IBloodConsuptionRepository
    {
        IEnumerable<BloodSupply> GetAll();
        BloodSupply GetById(int id);
        void Create(BloodSupply bloodSupply);
        void Update(BloodSupply bloodSupply);
        void Delete(BloodSupply bloodSupply);
        List<BloodSupply> GetByGroup(BloodType type);
    }
}