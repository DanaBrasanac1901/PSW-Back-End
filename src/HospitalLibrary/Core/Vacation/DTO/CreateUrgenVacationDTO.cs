using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation.DTO
{
    public class CreateUrgenVacationDTO
    {
        public string start { get; set; }
        public string end { get; set; }
        public string description { get; set; }
        public string urgency { get; set; }

        public CreateUrgenVacationDTO() { }
    }
}
