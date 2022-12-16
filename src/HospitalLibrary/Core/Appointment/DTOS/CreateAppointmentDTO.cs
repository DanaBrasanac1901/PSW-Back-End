using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class CreateAppointmentDTO
    {
        private IAppointmentService appointmentService;
        public string doctorId { get; set; }
        public string patientId { get; set; }
        public string startDate { get; set; }
        public string startTime { get; set; }
        public int roomId { get; set; }
        public string status { get; set; }
        public int appointmentDuration { get; set; }

        public CreateAppointmentDTO()
        {
        }
        public CreateAppointmentDTO(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
            doctorId = "DOC1";
            patientId = "PAT1";
            var helper = DateTime.Now;
            startDate = helper.Year +  "-" + helper.Month + "-" + helper.Day;
            startTime = helper.Hour + ":" + helper.Minute;
            roomId = 1;
            status = "bilosta";
            appointmentDuration = 20;
        }
    }
}
