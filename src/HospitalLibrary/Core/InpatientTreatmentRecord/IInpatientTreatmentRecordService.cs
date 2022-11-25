using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public interface IInpatientTreatmentRecordService
    {
        IEnumerable<InpatientTreatmentRecord> GetAll();
        InpatientTreatmentRecord GetById(string id);
        void Create(InpatientTreatmentRecord inpatientTreatmentRecord);
        void Update(InpatientTreatmentRecord inpatientTreatmentRecord);
        void Discharge(string requestId);
        string GenerateStringID();
        IEnumerable<InpatientTreatmentRecord> GetAllWithStatusTrue();
        IEnumerable<ViewAcceptedPatientsOnTreatmentDTO> GetAllByDoctor(string id);
        DischargeTreatmentDTO GetRecordForDischarged(string id);

    }
}
