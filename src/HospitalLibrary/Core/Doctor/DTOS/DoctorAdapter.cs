using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class DoctorAdapter
    {
        public DoctorsShiftDTO DoctorToDoctorsShiftDTO(Doctor doctor)
        {
            DoctorsShiftDTO doctorDTO = new DoctorsShiftDTO();
            doctorDTO.id = doctor.Id;
            doctorDTO.startWorkTime = doctor.StartWorkTime;
            doctorDTO.endWorkTime = doctor.EndWorkTime;
            return doctorDTO;
        }

        public List<DateTime> UrgentVacationParametersHandling(GetDoctorsAppointmentsForUrgentVacationDTO parameters)
        {
            List<DateTime> retList = new List<DateTime>();
            retList.Add(DateTime.Parse(parameters.vacationStart));
            retList.Add(DateTime.Parse(parameters.vacationEnd));
            return retList;
        }

        public GetAppointmentsUrgentVacationDTO AppointmentToGetAppointmentsUrgentVacationDTO(Appointment.Appointment app)
        {
            GetAppointmentsUrgentVacationDTO dto = new GetAppointmentsUrgentVacationDTO();
            dto.id = app.Id;
            dto.patient = app.PatientId;
            dto.date = app.Start.Year + "/" + app.Start.Month + "/" + app.Start.Day;
            dto.time = app.Start.Hour + "/" + app.Start.Minute;
            return dto;
        }
    }
}
