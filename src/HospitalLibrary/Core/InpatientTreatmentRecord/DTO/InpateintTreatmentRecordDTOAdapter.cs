using HospitalLibrary.Core.Vacation.DTO;
using HospitalLibrary.Core.Vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord.DTO
{
    public class InpateintTreatmentRecordDTOAdapter
    {
        public static InpatientTreatmentRecord InpatientTreatmentRecordDTOToObject(CreateInpatientTretmentRecordDTO recordDTO)
        {
            InpatientTreatmentRecord record = new InpatientTreatmentRecord();
            record.DoctorID = "DOC1";
            record.PatientID = recordDTO.patientId;
            record.RoomID = recordDTO.roomId;
            record.BedID = recordDTO.bedId;
            record.AdmissionReason = recordDTO.AdmissionReason;
            record.Therapy = recordDTO.Therapy;
            record.AdmissionDate = DateTime.Now;
            record.DischargeReason = "";
            record.Status = true;

            return record;
        }

        public static ViewAcceptedPatientsOnTreatmentDTO InpatientTreatmentRecordToDTO(InpatientTreatmentRecord record)
        {
            ViewAcceptedPatientsOnTreatmentDTO recordDto = new ViewAcceptedPatientsOnTreatmentDTO();
            recordDto.patientId = record.PatientID;
            //recordDto.patientName = record.patientName;
            //recordDto.PatientSurname = record.patientSurname
            recordDto.roomId = record.RoomID;
            recordDto.bedId = record.BedID;

            return recordDto;

        }
    }
}
