using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    internal class Patient
    {
        private String patientName;
        private String email;
        private String password;
        private BloodType bloodType;
        private String allergies;
        private String doctorID;
        private bool active;

        public Patient(string patientName, string email, string password, BloodType bloodType,
            string allergies, string doctorID, bool active)
        {
            this.patientName = patientName;
            this.email = email;
            this.password = password;
            this.bloodType = bloodType;
            this.allergies = allergies;
            this.doctorID = doctorID;
            this.active = active;
        }

        public string PatientName { get => patientName; set => patientName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public string Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public bool Active { get => active; set => active = value; }
    }
}
