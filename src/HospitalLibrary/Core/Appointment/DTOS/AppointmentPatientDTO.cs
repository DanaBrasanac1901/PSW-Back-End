using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    internal class AppointmentPatientDTO
    {
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string RoomNumber { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public AppointmentStatus Status { get; set; }

        public AppointmentPatientDTO() { }

        public AppointmentPatientDTO(Appointment appt)
        {

        }
    }
}
