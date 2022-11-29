using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class DrugList
    {
        public string Id { get; set; }
        public string DrugPrescriptionId { get; set; }
        public string Drug { get; set; }
        public string Amount { get; set; }

        public DrugList()
        {
        }
    }
}
