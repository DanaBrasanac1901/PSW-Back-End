using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient.DTOS
{
    public class SubmitPatientHealthMeasurementsDTO
    {
        public string PatientId { get; set; }
        public string Weight { get; set; }
        public string BloodPressureUpper { get; set; }
        public string BloodPressureLower { get; set; }
        public string Heartbeat { get; set; }
        public string Temperature { get; set; }
        public string BloodSugarLevel { get; set; }

    }
}
