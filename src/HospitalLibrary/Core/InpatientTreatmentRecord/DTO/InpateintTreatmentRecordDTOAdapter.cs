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
            
            //recordDto.patientName = record.patientName;
            //recordDto.PatientSurname = record.patientSurname
            
            recordDto.id=record.Id;
            recordDto.patientId = record.PatientID;
            recordDto.roomId = record.RoomID;
            recordDto.bedId = record.BedID;

            return recordDto;

        }

        public static DischargeTreatmentDTO DischargeToDTO(InpatientTreatmentRecord record)
        {
            DischargeTreatmentDTO recordDto = new DischargeTreatmentDTO();

            recordDto.id = record.Id;
            recordDto.patientId=record.PatientID;
            recordDto.roomId=record.RoomID;
            recordDto.bedId=record.BedID;
            recordDto.therapy=record.Therapy;
            
            recordDto.startDate = record.AdmissionDate.ToString("yyyy-MM-dd");
            recordDto.endDate = DateTime.Now.ToString("yyyy-MM-dd");
            recordDto.reason=record.DischargeReason;
               
            return recordDto;
        }
    }
}
