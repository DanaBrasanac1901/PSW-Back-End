using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Doctor
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Room Room { get; set; }

        [Range(0, 23)]
        public int StartWorkTime { get; set; }
        [Range(0, 23)]
        public int EndWorkTime { get; set; }
        
        public virtual ICollection<Appointment> Appointments{ get; set; }

        
        public Doctor() {}

        public Doctor(string id, string name, string surname, string email, Room room, int startWorkTime, int endWorkTime, ICollection<Appointment> appointments)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Room = room;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
            Appointments = appointments;
        }

        
        
    }
}
