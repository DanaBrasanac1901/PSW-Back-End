using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Jmbg { get; set; }
        public string ChosenDoctor { get; set; }
        public int Age { get; set; }
        public List<string> Allergies { get; set; }
        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Surname = patient.Surname;
            Gender=patient.Gender.ToString().ToLower();
            BloodType = patient.BloodType.ToString().ToUpper();
            Age=patient.Age;
            Allergies = patient.Allergies;
            Jmbg = patient.Jmbg;
            Address = patient.AddressString;
            Email=patient.Email;
        }

    }
}
