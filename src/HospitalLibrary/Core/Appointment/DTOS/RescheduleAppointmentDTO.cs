using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class RescheduleAppointmentDTO
    {
        public string AppointmentId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
