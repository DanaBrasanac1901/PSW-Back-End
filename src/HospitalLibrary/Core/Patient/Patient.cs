using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class Patient : Authorization.User
    {
        private int id;
        private String name;
        private String surname;
        private String email;
        private String password;
        private BloodType bloodType;
        private String allergies;
        private String doctorID;
        private bool active;
       

        public Patient() {}

        public Patient(int id, string patientName, string email, string password, BloodType bloodType, string allergies, string doctorID, bool active)
        {
            this.Id = id;
            this.Name = patientName;
            this.Email = email;
            this.Password = password;
            this.BloodType = bloodType;
            this.Allergies = allergies;
            this.DoctorID = doctorID;
            this.Active = active;
            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => name; set => name = value; }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public string Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public bool Active { get => active; set => active = value; }
       
    }
}
