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
        public List<SymptomDTO> Symptoms { set; get; }
        public string DayAndTimeOfMaking { get; set; }
        public string Description { get; set; }
        public List<DrugDTO> Prescriptions { get; set; }
        public string PatientId { get; set; }
        public string AppointmentId { get; set; }

        public SearchResultReportDTO() { }

    }
}
