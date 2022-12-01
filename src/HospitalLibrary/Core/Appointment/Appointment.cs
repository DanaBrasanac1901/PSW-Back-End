using System;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Room;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HospitalLibrary.Core.Appointment
{
    public class Appointment
    {
        private const int AppointmentDuration = 20;
        public string Id { get; set; }
        public string DoctorId { get; set; }
        [JsonIgnore]
        public virtual Doctor.Doctor Doctor { get; set; }
        public string PatientId { get; set; }
        //line below should be uncommented once Patients have been created
        public virtual Patient.Patient Patient {get; set;}
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public int RoomId { get; set; }
        [JsonIgnore]
        public virtual Room.Room Room { get; set; }
        public AppointmentStatus Status { get; set; }
        public Appointment() { }
        //constructor below should be changed once patients are added to the model(Patient object instead of patientId)
 

        public Appointment(string id, string doctorId, string patientId, DateTime start, int roomId)
        {
            Id = id;
            DoctorId = doctorId;
            Doctor = new Doctor.Doctor();
            Doctor.Id = doctorId;
            PatientId = patientId;
            Start = start;
            Duration = AppointmentDuration;
            RoomId = roomId;
            Status = AppointmentStatus.Scheduled;
        }
    }
}
