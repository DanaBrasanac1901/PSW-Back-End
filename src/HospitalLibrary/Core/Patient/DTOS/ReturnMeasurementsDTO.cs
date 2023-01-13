using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient.DTOS
{
    public class ReturnMeasurementsDTO
    {
       public string measurementTime { get; set; }
        public float weight { get; set; }
        public float bloodPressureUpper { get; set; }
        public float bloodPressureLower { get; set; }
        public float heartbeat { get; set; }
        public float temperature { get; set; }
        public float bloodSugarLevel { get; set; }

        public ReturnMeasurementsDTO(PatientHealthMeasurements phm)
        {
            this.measurementTime = phm.MeasurementTime.ToString();
            this.weight = phm.HealthMeasurements.Weight;
            this.bloodPressureUpper = phm.HealthMeasurements.BloodPressureUpper;
            this.bloodPressureLower = phm.HealthMeasurements.BloodPressureLower;
            this.heartbeat = phm.HealthMeasurements.Heartbeat;
            this.temperature = phm.HealthMeasurements.Temperature;
            this.bloodSugarLevel = phm.HealthMeasurements.BloodSugarLevel;
        }
    }
}
