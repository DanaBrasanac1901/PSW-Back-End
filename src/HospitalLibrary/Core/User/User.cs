using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.User
{
    public class User
    {
        int id;
        
        string name;
        string surname;
        string email;
        string password;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return } set { surname = value;  } }
        string Email { get { return email; } set { email = value; } }
        string Password { get { return password; } set { password = value; } }

    }
}
