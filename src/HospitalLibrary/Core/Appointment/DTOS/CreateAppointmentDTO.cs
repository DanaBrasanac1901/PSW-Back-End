using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class CreateAppointmentDTO
    {
        public string doctorId { get; set; }
        public string patientId { get; set; }
        public string start { get; set; }
        public int roomId { get; set; }
        public string status { get; set; }
        public int appointmentDuration { get; set; }

        public CreateAppointmentDTO()
        {
        }
    }
}
