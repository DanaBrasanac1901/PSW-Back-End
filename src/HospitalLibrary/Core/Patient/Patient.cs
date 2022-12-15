using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.User;
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
        private Address adress;
        private string jmbg;
        private Gender gender;
        private int age;
        private BloodType bloodType;
        private List<string> allergies;
        private string doctorID;

        public Patient() {}

        public Patient(RegisterDTO regDTO)
        {
            this.name = regDTO.Name;
            this.surname=regDTO.Surname;
            this.email = regDTO.Email;
            this.adress = MakeAddress(regDTO.Address);
            this.jmbg = regDTO.Jmbg;
            Gender.TryParse(regDTO.Gender, out this.gender);
            this.age = regDTO.Age;
            BloodType.TryParse(regDTO.BloodType,out this.bloodType);
            
            this.allergies=new List<string>();
            
            foreach (string allergy in regDTO.Allergies)
            {
                allergies.Add(allergy);
            }
            this.doctorID = regDTO.DoctorId;
        }

        private Address MakeAddress(string address)
        {
            string[] all = address.Split(" ");
            return new Address(all[0], all[1], all[2]);
        }

        public override bool Equals(Object obj)
        {
            if(obj is Patient)
            {
                Patient patient = (Patient)obj;
                return this.Id == patient.Id && this.Jmbg.Equals(patient.Jmbg);
            }
            return false;
            
        }

        public override int GetHashCode()
        {
            return (this.Id.GetHashCode() * 3 - 4) ^ this.Email.GetHashCode();  
        }

        public Patient(int id, string name, string surname, string email, Gender gender, int age, BloodType bloodType, List<string> allergies, string doctorID)
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
            
        }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public Address Address { get => adress; }
        public string Email { get => email; set => email = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public List<string> Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
    }
}
