using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class ViewAllAppointmentsDTO
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string RoomNumber { get; set; }
        public string Start { get; set; }
        public AppointmentStatus Status { get; set; }
   
        public ViewAllAppointmentsDTO() { }

    }
}
