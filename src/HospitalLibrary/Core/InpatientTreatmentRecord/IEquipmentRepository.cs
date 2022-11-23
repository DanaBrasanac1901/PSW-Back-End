using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAll();
        Equipment GetById(string id);
        void Create(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(Equipment equipment);
        Equipment GetByType(EquipmentType type);

    }
}
