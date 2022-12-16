using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class Consilium
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Topic { get; set; }
        public int Duration { get; set; }
        public string Specialties { get; set; }
        public string DoctorIds { get; set; }
        public DateTime Start { get; set; }
       

        public bool Finished { get; set; }
        public string CreatedBy { get; set; }
        public int RoomId { get; set; }
        [JsonIgnore]
        public virtual ICollection<ConsiliumAppointment> ConsiliumAppointments { get; set; }

        public Consilium() { }
        public Consilium(int id, string topic, int duration, DateTime start, string doctorIds, string specilaties, string createdBy)
        {
            Topic = topic;
            Duration = duration;
            DoctorIds = doctorIds;
            Specialties = specilaties;
            Finished = false;
            Start = start;
            CreatedBy = createdBy;
            RoomId = 999;
        }         
    }
}
