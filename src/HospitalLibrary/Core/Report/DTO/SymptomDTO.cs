using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class SymptomDTO
    {
        public string name { get; set; }
        public Boolean isChecked { get; set; }

        public SymptomDTO()
        {

        }

        public SymptomDTO(string name)
        {
            this.name = name;
        }
    }
}
