using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient.DTOS
{
    public class CreatePatientHealthMeasurementsDTO
    {
        public int PatientId { get; set; }
        public float Weight { get; set; }
        public int BloodPressureUpper { get; private set; }
        public int BloodPressureLower { get; private set; }
        public int Heartbeat { get; private set; }
        public float Temperature { get; private set; }
        public float BloodSugarLevel { get; private set; }
    }
}
