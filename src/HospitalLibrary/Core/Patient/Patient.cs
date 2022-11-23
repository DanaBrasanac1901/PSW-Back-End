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
        private int id;
        private string name;
        private string surname;
        private string email;
        private Gender gender;
        private int age;
        private BloodType bloodType;
        private string allergies;
        private string doctorID;
        private bool active;
       

        public Patient() {}

        public Patient(int id, string name, string surname, string email, Gender gender, int age, BloodType bloodType, string allergies, string doctorID, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Gender = gender;
            this.Age = age;
            this.BloodType = bloodType;
            this.Allergies = allergies;
            this.DoctorID = doctorID;
            this.Active = active;
            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => name; set => name = value; }

        public string Email { get => email; set => email = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public string Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public bool Active { get => active; set => active = value; }
       
    }
}
