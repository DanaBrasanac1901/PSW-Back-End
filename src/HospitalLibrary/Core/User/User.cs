using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.User
{
    public class User
    {
        public User(int id, int idByRole, string name, string surname, string email,string password, string role, string token)
        {
            this.Id = id;
            this.IdByRole = idByRole;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.Token = token;

        }

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
        }

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

        public int Id { get { return id; } set { id = value; } }
        public int IdByRole { get { return idByRole; } set { idByRole = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value;  } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Role { get { return role; } set { role = value; } }

        public bool Active { get => active; set => active = value; }
        public string Token { get { return token; } set { token = value; } }   
    }
}
