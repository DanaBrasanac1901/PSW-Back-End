using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class CreateAppointmentDTO
    {
        public string id { get; set; }
        public string doctorId { get; set; }
        public string patientId { get; set; }
        public string start { get; set; }
        public int roomId { get; set; }
        public string status { get; set; }
        public int appointmentDuration { get; set; }

        public CreateAppointmentDTO()
        {
        }

        public CreateAppointmentDTO(string id, string ioctorId, string iatientId, string itart, int ioomId, string itatus, int appointmentDuration)
        {
            this.id = id;
            this.doctorId = ioctorId;
            this.patientId = iatientId;
            this.start = itart;
            this.roomId = ioomId;
            this.status = itatus;
            this.appointmentDuration = appointmentDuration;
        }
    }
}
