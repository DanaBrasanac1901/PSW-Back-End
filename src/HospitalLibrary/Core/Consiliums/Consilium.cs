using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class Consilium
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public int Duration { get; set; }
        public string Specialties { get; set; }
        public string DoctorIds { get; set; }

        [Column(TypeName = "jsonb")]
        public DateTimeRange FromTo { get; set; }
       

        public bool Finished { get; set; }
        public string CreatedBy { get; set; }
        public int RoomId { get; set; }
        public virtual ICollection<ConsiliumAppointment> ConsiliumAppointments { get; set; }

        public Consilium() { }
        public Consilium(int id, string topic, int duration, DateTime start, string doctorIds, string specilaties, string createdBy)
        {
            Id = id;
            Topic = topic;
            Duration = duration;
            DoctorIds = doctorIds;
            Specialties = specilaties;
            Finished = false;
            FromTo = new DateTimeRange(start, start.AddMinutes(duration));
            CreatedBy = createdBy;
            RoomId = 999;
        }         
    }
}
