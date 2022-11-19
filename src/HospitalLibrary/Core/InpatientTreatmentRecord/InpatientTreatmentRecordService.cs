using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class InpatientTreatmentRecordService : IInpatientTreatmentRecordService
    {
        private readonly IInpatientTreatmentRecordRepository _inpatientTreatmentRecordRepository;

        public InpatientTreatmentRecordService(IInpatientTreatmentRecordRepository inpatientTreatmentRecordRepository)
        {
            _inpatientTreatmentRecordRepository = inpatientTreatmentRecordRepository;
        }

        public IEnumerable<InpatientTreatmentRecord> GetAll()
        {
            return _inpatientTreatmentRecordRepository.GetAll();
        }

        public InpatientTreatmentRecord GetById(string id)
        {
            return _inpatientTreatmentRecordRepository.GetById(id);
        }

        public void Create(InpatientTreatmentRecord inpatientTreatmentRecord)
        {
            _inpatientTreatmentRecordRepository.Create(inpatientTreatmentRecord);
        }

        public void Update(InpatientTreatmentRecord inpatientTreatmentRecord)
        {
            _inpatientTreatmentRecordRepository.Update(inpatientTreatmentRecord);
        }

        public void Delete(InpatientTreatmentRecord inpatientTreatmentRecord)
        {
            _inpatientTreatmentRecordRepository.Delete(inpatientTreatmentRecord);
        }

        public void Disapprove(string requestId)
        {
            InpatientTreatmentRecord record = _inpatientTreatmentRecordRepository.GetById(requestId);
            record.Status = false;
            _inpatientTreatmentRecordRepository.Update(record);
        }
    }
}
