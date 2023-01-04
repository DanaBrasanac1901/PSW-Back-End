using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class PatientHealthMeasurements
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime MeasurementTime { get; set; }
        public HealthMeasurements HealthMeasurements { get; set; }

        public PatientHealthMeasurements(int patientId, float weight, int bloodPressureUpper, int bloodPressureLower, int heartbeat, float temperature, float bloodSugarLevel)
        {
            PatientId = patientId;
            MeasurementTime = DateTime.Now;
            HealthMeasurements = new HealthMeasurements(weight, bloodPressureUpper, bloodPressureLower, heartbeat, temperature, bloodSugarLevel);
        }
    }
}
