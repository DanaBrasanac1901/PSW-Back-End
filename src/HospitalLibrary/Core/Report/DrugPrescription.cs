using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class DrugPrescription
    {
        public string Id { get; set; }
        public ICollection<Drug> Drugs { get; set; }

        public DrugPrescription()
        {
        }
    }
}
