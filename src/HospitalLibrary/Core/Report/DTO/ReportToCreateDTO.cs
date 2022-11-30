using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportToCreateDTO
    {
        public string patientId {get;set;}
        public string doctorId { get; set; }
        public string description { get; set; }
        public string DATOfMaking { get; set; }
        public List<string> symptoms { get; set; }
        public List<string> drugs { get; set; }

        public ReportToCreateDTO()
        {

        }
    }
}
