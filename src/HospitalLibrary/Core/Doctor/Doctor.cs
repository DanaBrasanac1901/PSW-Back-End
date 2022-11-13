using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Vacation;


namespace HospitalLibrary.Core.Doctor
{
    public class Doctor
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public virtual Room.Room Room { get; set; }

        [Range(0, 23)]
        public int StartWorkTime { get; set; }
        [Range(0, 23)]
        public int EndWorkTime { get; set; }

        public virtual ICollection<VacationRequest> VacationRequests { get; set; }
        
        public virtual ICollection<Appointment.Appointment> Appointments{ get; set; }

        
        public Doctor() {}

        public Doctor(string id, string name, string surname, string email,int roomId, Room.Room room, int startWorkTime, int endWorkTime, ICollection<Appointment.Appointment> appointments)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            RoomId = roomId;
            Room = room;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
            Appointments = appointments;
        } 

        public bool IsAvailable(DateTime start, DateTime end)
        {
            bool hasAppointments = HasAppointments(start, end);
            bool hasVacation = HasVacations(start, end);

            return !(hasAppointments || hasVacation);
        }

        private bool HasAppointments(DateTime start, DateTime end)
        {
            foreach(Appointment.Appointment appointment in this.Appointments)
            {
                if (appointment.Start >= start && appointment.Start <= end)
                    return true;
            }

            return false;
        }

        private bool HasVacations(DateTime start, DateTime end)
        {
            foreach (VacationRequest vacationRequest in this.VacationRequests)
            {
                if (AreOverlapping(vacationRequest, start, end))
                    return true;
            }

            return false;
        }

        private bool AreOverlapping(VacationRequest request, DateTime start, DateTime end)
        {
            //implementirati logiku za overlap dva vacation-a (moze i da se uvede DateRange klasa i da se u njoj proveravaju takve stvari)
            return false;
        }


    }
}
