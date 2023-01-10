using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;

namespace HospitalLibrary.Core.Report.DTO
{
    public class SearchResultReportDTO
    {
        public List<SymptomDTO> symptoms { set; get; }
        public string dayAndTimeOfMaking { get; set; }
        public string description { get; set; }
        public List<DrugDTO> prescriptions { get; set; }
        public string patientId { get; set; }
        public string appointmentId { get; set; }

        public SearchResultReportDTO() { }

    }
}
