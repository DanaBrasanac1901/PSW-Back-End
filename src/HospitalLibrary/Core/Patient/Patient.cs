using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{

    public class Patient
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private string jmbg;
        private Gender gender;
        private int age;
        private BloodType bloodType;
        private List<string> allergies;
        private string doctorID;
        private bool active;
       
        public Patient() {}
      
        public Patient(RegisterDTO regDTO)
        {
            this.name = regDTO.Name;
            this.surname=regDTO.Surname;
            this.email = regDTO.Email;
            this.Address = MakeAddress(regDTO.Address);
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
            string[] all = address.Split(",");
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

        public Patient(int id, string name, string surname, string address, string email, Gender gender, int age, BloodType bloodType, List<string> allergies, string doctorID)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Address = MakeAddress(address);
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
        private string addressJson { get; set; }
        [Column(TypeName = "jsonb")]
        public string AddressJson
        {
            get => addressJson; set
            {
                addressJson = value;
                Address = JsonSerializer.Deserialize<Address>(addressJson);
                AddressString = Address.ToString();
            }
        }
        [NotMapped]
        private Address address { get; set; }
        [NotMapped]
        public Address Address
        {
            get => address; set
            {
                address = value;
            }
        }
        [NotMapped]
        public string AddressString { get; set; }
        public string Email { get => email; set => email = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public BloodType BloodType { get => bloodType; set => bloodType = value; }
        public List<string> Allergies { get => allergies; set => allergies = value; }
        public string DoctorID { get => doctorID; set => doctorID = value; }
        public bool Active { get => active; set => active = value; }

        public string Jmbg { get => jmbg; set => jmbg = value; }
    }
}
