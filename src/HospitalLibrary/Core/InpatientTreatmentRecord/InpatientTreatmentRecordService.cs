using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Vacation.DTO;
using Org.BouncyCastle.Asn1.Ocsp;
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

        public void Discharge(string requestId)
        {
            InpatientTreatmentRecord record = _inpatientTreatmentRecordRepository.GetById(requestId);
            record.Status = false;
            record.DischargeDate = DateTime.Now;
            _inpatientTreatmentRecordRepository.Update(record);
        }

        public string GenerateStringID()
        {
            List<string> ids = new List<string>();
            IEnumerable<InpatientTreatmentRecord> records = _inpatientTreatmentRecordRepository.GetAll();
            ids = records.Select(r => r.Id).ToList();
            if (ids.Count == 0)
            {
                return "ITREC0";
            }
            else
            {
                return "ITREC" + ids.Count();
            }
        }

        public IEnumerable<InpatientTreatmentRecord> GetAllWithStatusTrue()
        {
           return _inpatientTreatmentRecordRepository.GetAllWithStatusTrue();
        }

        public IEnumerable<ViewAcceptedPatientsOnTreatmentDTO> GetAllByDoctor(string id)
        {
            IEnumerable<InpatientTreatmentRecord> records = _inpatientTreatmentRecordRepository.GetAllByDoctor(id);

            List<ViewAcceptedPatientsOnTreatmentDTO> recordsDTO = new List<ViewAcceptedPatientsOnTreatmentDTO>();

            foreach (InpatientTreatmentRecord record in records)
            {
                if (record.Status==true)

                recordsDTO.Add(InpateintTreatmentRecordDTOAdapter.InpatientTreatmentRecordToDTO(record));
            }
            return recordsDTO;
        }

        public DischargeTreatmentDTO GetRecordForDischarged(string id)
        {
            InpatientTreatmentRecord record = _inpatientTreatmentRecordRepository.GetById(id);

            DischargeTreatmentDTO recordDTO = new DischargeTreatmentDTO();

            recordDTO = InpateintTreatmentRecordDTOAdapter.DischargeToDTO(record);

            return recordDTO;

         

        }
    }
}
