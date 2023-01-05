using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient.DTOS
{
    public class GetPatientHealthMeasurementsDTO
    {
        public string Month { get; set; }
        public string PatientId { get; set; }
    }
}
