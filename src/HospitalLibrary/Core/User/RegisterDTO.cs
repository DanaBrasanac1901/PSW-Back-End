using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.User
{
    public class RegisterDTO
    {
        private string email;
        private string password;
        private string name;
        private string surname;
        private string address;
        private string gender;
        private string jmbg;
        private string bloodType;
        private string[] allergies;
        private int doctorID;
        private int age;

        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string Jmbg { get { return jmbg; } set { jmbg = value;} }
        public string BloodType { get { return bloodType; } set { bloodType = value; } }
        public string[] Allergies { get { return allergies; } set { allergies = value; } }
        public int DoctorId { get { return doctorID; } set { doctorID = value; } }
        public int Age { get { return age; } set { age = value; } }

    }
}
