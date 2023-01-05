using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public interface IInpatientTreatmentRecordRepository
    {
        IEnumerable<InpatientTreatmentRecord> GetAll();
        InpatientTreatmentRecord GetById(string id);
        void Create(InpatientTreatmentRecord inpatientTreatmentRecord);
        void Update(InpatientTreatmentRecord inpatientTreatmentRecord);
        void Delete(InpatientTreatmentRecord inpatientTreatmentRecord);
        IEnumerable<InpatientTreatmentRecord> GetAllWithStatusTrue();
        IEnumerable<InpatientTreatmentRecord> GetAllByDoctor(int id);
    }
}
