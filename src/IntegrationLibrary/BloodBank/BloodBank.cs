
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IntegrationLibrary.BloodBank
{
    public class BloodBank
    {
        public Guid Id { get; set; }
        

        public string Username { get; set; }

        public string Path { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Apikey { get; set; }

    }
}
