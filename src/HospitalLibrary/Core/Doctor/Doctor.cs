using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Enums;

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

        public Specialty Specialty { get; set; }

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
            VacationRequests = new List<VacationRequest>();
        }

        public Doctor(string id, string name, string surname, string email, int roomId, Room.Room room, int startWorkTime, int endWorkTime, ICollection<Appointment.Appointment> appointments, int specialty)
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
            VacationRequests = new List<VacationRequest>();
            Specialty = (Specialty)specialty;
        }

        public bool IsAvailable(DateTime start, DateTime end)
        {
            DateTimeRange range = new DateTimeRange(start, end);
            bool hasAppointments = HasAppointments(range);
            bool hasVacation = HasVacations(range);

            return !(hasAppointments || hasVacation);
        }

        private bool HasAppointments(DateTimeRange rangeToCheck)
        {
            if(Appointments != null)
                foreach(Appointment.Appointment appointment in Appointments)
                {
                    DateTimeRange appointmentRange = new DateTimeRange(appointment.Start, appointment.Start.AddMinutes(20));
                    if (appointmentRange.OverlapsWith(rangeToCheck)
                        && appointment.Status==AppointmentStatus.Scheduled)
                        return true;
                }

            return false;
        }

        private bool HasVacations(DateTimeRange rangeToCheck)
        {
            foreach (VacationRequest vacationRequest in this.VacationRequests)
            {
                DateTimeRange existingRequestRange = new DateTimeRange(vacationRequest.Start, vacationRequest.End);

                if(existingRequestRange.OverlapsWith(rangeToCheck) && 
                    (
                    vacationRequest.Status == Enums.VacationRequestStatus.WaitingForApproval ||
                    vacationRequest.Status == Enums.VacationRequestStatus.Accepted
                    )
                  )
                    return true;
            }

            return false;
        }

    }
}
