using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class SymptomList
    {
        public string Id { get; set; }
        public string ReportId { get; set; }
        public string Symptom { get; set; }
        public string Severity { get; set; }

        public SymptomList()
        {
        }
    }
}
