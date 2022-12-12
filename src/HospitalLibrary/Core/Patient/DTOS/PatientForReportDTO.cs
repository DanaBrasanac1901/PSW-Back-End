using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient.DTOS
{
    public class PatientForReportDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string bloodType { get; set; }

        public PatientForReportDTO()
        {

        }

    }
}
