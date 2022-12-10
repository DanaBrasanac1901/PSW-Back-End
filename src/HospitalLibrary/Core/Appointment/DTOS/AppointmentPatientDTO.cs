using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    
    public class AppointmentPatientDTO
    {
        public string Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string RoomNumber { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string Status { get; set; }

        public AppointmentPatientDTO() { }

        public AppointmentPatientDTO(Appointment appt)
        {
            Id=appt.Id;
            DoctorId=appt.DoctorId;
            StartDate = appt.Start.Date.ToString();
            StartTime = appt.Start.TimeOfDay.ToString();
            Status=appt.Status.ToString();
            RoomNumber = appt.RoomId.ToString();
        }
    }
}
