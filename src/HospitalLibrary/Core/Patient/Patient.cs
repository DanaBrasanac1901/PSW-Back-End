using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class Patient
    {
        private String patientName;
        private String email;
        private String password;
        private BloodType bloodType;
        private String allergies;
        private String doctorID;
        private bool active;
        private int id;

        public Patient(string patientName, string email, string password, BloodType bloodType, string allergies, string doctorID, bool active, int id)
        {
            this.PatientName = patientName;
            this.Email = email;
            this.Password = password;
            this.BloodType = bloodType;
            this.Allergies = allergies;
            this.DoctorID = doctorID;
            this.Active = active;
            this.Id = id;
        }

        public string PatientName { get => patientName; set => patientName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public string Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public bool Active { get => active; set => active = value; }
        public int Id { get => id; set => id = value; }
    }
}
