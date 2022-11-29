using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class Report
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string ReportDescription { get; set; }
        public ICollection<Symptom> Symptoms { get; set; }

        public string DrugPrescriptionId { get; set; }
        public DateTime DayAndTimeOfMaking { get; set; }

        public Report()
        {
        }
    }
}
