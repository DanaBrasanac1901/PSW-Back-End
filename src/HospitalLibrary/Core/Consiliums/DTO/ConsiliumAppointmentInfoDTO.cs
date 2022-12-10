using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class ConsiliumAppointmentInfoDTO
    {
        //public string Start { get; set; }
        //public string End { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int Duration { get; set; }
        public string DoctorIds { get; set; }
        public string Specialties { get; set; }


        public ConsiliumAppointmentInfoDTO() { }
        public ConsiliumAppointmentInfoDTO(DateTimeRange appointmentTime, int duration=0, string doctorIds="")
        {
           // Start = appointmentTime.GetStartString();
            //End = appointmentTime.GetEndString();
            Start = appointmentTime.Start;
            End = appointmentTime.End;
            Duration = duration;
            DoctorIds = doctorIds;
        }
    }
}
