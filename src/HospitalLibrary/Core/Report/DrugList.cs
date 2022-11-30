using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class DrugList
    {
        public string Id { get; set; }
        public string DrugPrescriptionId { get; set; }
        [Column(TypeName = "jsonb")]
        public Drug Drug { get; set; }


        public DrugList()
        {
        }
    }
}
