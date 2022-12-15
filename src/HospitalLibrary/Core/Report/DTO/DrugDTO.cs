using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class DrugDTO
    {
        public string name { get; set; }
        public string companyName { get; set; }

        public  Boolean isChecked { get;set; }

        public DrugDTO()
        {

        }
    }
}
