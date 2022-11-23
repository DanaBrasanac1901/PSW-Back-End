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
        private String name;
        private String surname;
        private BloodType bloodType;
        private String allergies;
        private String doctorID;
        private bool active;
       

        public Patient() {}

        public Patient(int id, string name, string surname, BloodType bloodType, string allergies, string doctorID, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.BloodType = bloodType;
            this.Allergies = allergies;
            this.DoctorID = doctorID;
            this.Active = active;
            
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => name; set => name = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public string Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public bool Active { get => active; set => active = value; }
       
    }
}
