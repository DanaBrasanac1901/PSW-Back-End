using HospitalLibrary.Core.Patient.DTOS;
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

        public PatientHealthMeasurements() { }
        public PatientHealthMeasurements(int patientId, float weight, int bloodPressureUpper, int bloodPressureLower, int heartbeat, float temperature, float bloodSugarLevel)
        {
            PatientId = patientId;
            MeasurementTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            HealthMeasurements = new HealthMeasurements(weight, bloodPressureUpper, bloodPressureLower, heartbeat, temperature, bloodSugarLevel);
        }
        public PatientHealthMeasurements(int patientId, DateTime time, float weight, int bloodPressureUpper, int bloodPressureLower, int heartbeat, float temperature, float bloodSugarLevel)
        {
            PatientId = patientId;
            MeasurementTime = time;
            HealthMeasurements = new HealthMeasurements(weight, bloodPressureUpper, bloodPressureLower, heartbeat, temperature, bloodSugarLevel);
        }
    }
}
