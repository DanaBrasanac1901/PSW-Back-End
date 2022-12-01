using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class Consilium
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public int Duration { get; set; }
        public virtual ICollection<Doctor.Doctor> Doctors { get; set; }
        public string Specialties { get; set; }
        public DateTimeRange FromTo { get; set; }
        public bool Finished { get; set; }

        public Consilium() { }
        public Consilium(int id, string topic, int duration, DateTime start, ICollection<Doctor.Doctor> doctors, string specilaties)
        {
            Id = id;
            Topic = topic;
            Duration = duration;
            Doctors = doctors;
            Specialties = specilaties;
            Finished = false;
            FromTo = new DateTimeRange(start, start.AddMinutes(duration));
        }         
    }
}
