using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class ShowConsiliumDTO
    {
        public string Start { get; set; }
        public int Duration { get; set; }
        public List<string> DoctorNames { get; set; }
        public int RoomId { get; set; }
        public string Topic { get; set; }

        public ShowConsiliumDTO(){}

        public ShowConsiliumDTO(Consilium consilium)
        {
            Start = consilium.FromTo.Day.ToString() + '/' + consilium.FromTo.Month.ToString() + '/' + consilium.FromTo.Year.ToString() + ' ' + consilium.FromTo.Hour.ToString() + ':' + consilium.FromTo.Minute.ToString();
            Duration = consilium.Duration;
            RoomId = consilium.RoomId;
            Topic = consilium.Topic;
            DoctorNames = ExtractDoctorNames(consilium.ConsiliumAppointments.ToList());
        }


        private List<string> ExtractDoctorNames(List<ConsiliumAppointment> appointments)
        {
            List<string> doctorNames = new List<string>();
            foreach(ConsiliumAppointment appointment in appointments)
            {
                doctorNames.Add(appointment.Doctor.Name + ' ' + appointment.Doctor.Surname);
            }
            return doctorNames;
        }
    }
}
