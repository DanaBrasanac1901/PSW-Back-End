using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportToShowDTO
    {
        public string id { get; set; }
        public List<SymptomDTO> symptoms { get; set; }
        public int patientId { get; set; }
        public string description { get; set; }
        public string appointmentId { get; set; }

        public ReportToShowDTO()
        {

        }
    }
}
