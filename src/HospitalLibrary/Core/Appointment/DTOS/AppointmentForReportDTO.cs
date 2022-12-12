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
        public string patientId { get; set; }
        public string doctorId { get; set; }

        public AppointmentForReportDTO()
        {

        }
    }
}
