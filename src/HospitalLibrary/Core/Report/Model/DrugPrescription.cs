using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class DrugPrescription
    {
        public string Id { get; set; }
        public string ReportId { get; set; }
        [Column(TypeName = "jsonb")]
        public  ICollection<Drug> Drugs { get; set; }

        public DrugPrescription()
        {
        }

        public DrugPrescription(string id, string reportId, ICollection<Drug> drugs)
        {
            Id = id;
            ReportId = reportId;
            Drugs = drugs;
        }

        public bool ContainsAny(string[] searchWords)
        {
            foreach(Drug drug in Drugs)
            {
                if (drug.ContainsAny(searchWords))
                    return true;
            }

            return false;
        }
    }
}
