using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums.DTO
{
    public class PotentialAppointmentsDTO
    {
        private IConsiliumService consiliumService;

        public string Start { get; set; }
        public string End { get; set; }
        public string DoctorIds { get; set; }
        public int Duration { get; set; }
        public string Specialties { get; set; }
        public string Topic { get; set; }

        public PotentialAppointmentsDTO() { }
        public PotentialAppointmentsDTO(string topic, DateTime start, DateTime end, int duration, List<Doctor.Doctor> doctors, string specialties)
        {
            DoctorIds = ExtractIds(doctors);
            Specialties = specialties;
            Topic = topic;
            Duration = duration;
            Start = start.Day.ToString() + '/' + start.Month.ToString() + '/' + start.Year.ToString() + ' ' + start.Hour.ToString() + ':' + start.Minute.ToString();
            End = end.Day.ToString() + '/' + end.Month.ToString() + '/' + end.Year.ToString() + ' ' + end.Hour.ToString() + ':' + end.Minute.ToString();
        }

        public PotentialAppointmentsDTO(IConsiliumService consiliumService)
        {
            Topic = "A consilium to discuss the further treatment of a patient";
            Start = "24/4/2023 15:45";
            End = "24/4/2023 16:30";
            Duration = 45;
            Specialties = "";
            DoctorIds = "DOC1";


            this.consiliumService = consiliumService;
        }

        private string ExtractIds(List<Doctor.Doctor> doctors)
        {
            string ids = "";
            foreach (Doctor.Doctor doctor in doctors)
                ids += (doctor.Id + ",");

            ids = ids.Substring(0, ids.Length - 1);

            return ids;
        }
        public Consilium ConvertToConsilium()
        {
            
            return new Consilium(0, Topic, Duration, StringToDateTime(Start), DoctorIds, Specialties, "DOC1");
        }

        private DateTime StringToDateTime(string start)
        {
            string[] startStrSplit = start.Split(' ');
            string[] dateStrSplit = startStrSplit[0].Split('/');

            int day = Int32.Parse(dateStrSplit[0]);
            int month = Int32.Parse(dateStrSplit[1]);
            int year = Int32.Parse(dateStrSplit[2]);

            string[] timeStrSplit = startStrSplit[1].Split(':');
            int hours = Int32.Parse(timeStrSplit[0]);
            int minutes = Int32.Parse(timeStrSplit[1]);

            return new DateTime(year, month, day, hours, minutes, 0);
        }


    }
}
