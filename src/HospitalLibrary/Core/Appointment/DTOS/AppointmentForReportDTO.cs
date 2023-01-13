using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class AppointmentForReportDTO
    {
        public string id { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }

        public AppointmentForReportDTO()
        {

        }
    }
}
