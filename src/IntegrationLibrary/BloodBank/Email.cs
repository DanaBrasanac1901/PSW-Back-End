using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBank
{
    public class Email
    {

       public string  To { get; set; }
       public string From { get; set; }
       public string Password { get; set; }


        public Email(string to, string from, string password)
        {
            To = to;
            From = from;
            Password = password;
        }   
    }
}
