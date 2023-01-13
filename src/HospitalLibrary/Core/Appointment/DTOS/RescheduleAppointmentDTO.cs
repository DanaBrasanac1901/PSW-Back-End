using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class RescheduleAppointmentDTO
    {
        public string id { get; set; }
        public int patientId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
