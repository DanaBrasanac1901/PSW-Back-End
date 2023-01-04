using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Advertisements
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public Advertisement(int id, string ad)
        {
            Id = id;
            Ad = ad;
        }
    }
}
