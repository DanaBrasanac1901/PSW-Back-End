using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.User
{
    public class User : ValueObject<User>
    {
        [Key]
        int id;
        int idByRole;
        string name;
        string surname;
        string email;
        string password;
        string role;
        bool active;
        string token;

        public User()
        {

        }

        public User(RegisterDTO regDTO, int roleID) //samo pacijent moze da se registruje
        {
            this.Role = "PATIENT";
            this.idByRole= roleID;
            this.name = regDTO.Name;
            this.surname = regDTO.Surname;
            this.email = regDTO.Email;
            this.password = regDTO.Password;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.name)) throw new ArgumentException();
            if (string.IsNullOrWhiteSpace(this.surname)) throw new ArgumentException();
            if (string.IsNullOrWhiteSpace(this.email)) throw new ArgumentException();
            if (string.IsNullOrWhiteSpace(this.password))  throw new ArgumentException();

            Regex r=new Regex("^.*(?=.{6,})(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!&$%&?\"]).*$");
            Match m=r.Match(this.password);
            if (!m.Success) throw new ArgumentException();
        }
       

        public int Id { get { return id; } set { id = value; } }
        public int IdByRole { get { return idByRole; } set { idByRole = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value;  } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Role { get { return role; } set { role = value; } }

        public bool Active { get => active; set => active = value; }
        public string Token { get { return token; } set { token = value; } }

        protected override bool EqualsCore(User other)
        {
            return Id == other.Id
            && IdByRole == other.IdByRole
            && Email.Equals(other.Email)
            && Role.Equals(other.Role);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hash = 11;
                hash = hash * 31 + id;
                hash = hash * 31 + idByRole;
                return hash;
            }
        }
    }
}
