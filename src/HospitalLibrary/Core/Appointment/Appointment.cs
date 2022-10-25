using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Model 
{
    public class Appointment {
        private const int AppointmentDuration = 20;
        public string Id {get;  set;}
        public string DoctorId {get; set;}
        public virtual Doctor Doctor {get; set;}
        public string PatientId {get; set;}
        //line below should be uncommented once Patients have been created
        //public virtual Patient Patient {get; set;}
        public DateTime Start {get; set;}
        public int Duration {get; set;}
        public int RoomId { get; set; }
        public virtual Room Room {get; set;}
        public AppointmentStatus Status {get; set;}
        public Appointment() {}
        //constructor below should be changed once patients are added to the model(Patient object instead of patientId)
        public Appointment(string id,string doctorId, string patientId, DateTime start,int roomId){
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            Start = start;
            Duration = AppointmentDuration;
            RoomId = roomId;
            Status = AppointmentStatus.Scheduled;
        }
    }
}