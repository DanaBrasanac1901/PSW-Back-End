using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient.DTOS
{
    public class PatientAdapter
    {
        public static PatientForAppointmentDTO PatientToPatientForAppointmentDTO(Patient pat)
        {
            PatientForAppointmentDTO dto = new PatientForAppointmentDTO();
            dto.id = pat.Id;
            dto.name = pat.Name;
            dto.surname = pat.Surname;
            return dto;
        }

        public static PatientForReportDTO PatientToPatientForReportDTO(Patient pat)
        {
            PatientForReportDTO dto = new PatientForReportDTO();
            dto.id = pat.Id;
            dto.name = pat.Name;
            dto.surname = pat.Surname;
            dto.age = pat.Age;
            dto.bloodType = pat.BloodType.ToString();
            return dto;
        }
    }
}
