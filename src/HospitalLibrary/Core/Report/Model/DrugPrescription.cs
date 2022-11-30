using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class DrugPrescription
    {
        public string Id { get; set; }
        public string ReportId { get; set; }
        [Column(TypeName = "jsonb")]
        public  virtual ICollection<Drug> Drugs { get; set; }

        public DrugPrescription()
        {
        }
    }
}
