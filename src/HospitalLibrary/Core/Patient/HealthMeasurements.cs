using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    [Owned]
    public class HealthMeasurements : ValueObject
    {
        public float Weight { get; private set; }
        public int BloodPressureUpper { get; private set; }
        public int BloodPressureLower { get; private set; }
        public int Heartbeat { get; private set; }
        public float Temperature { get; private set; }
        public float BloodSugarLevel { get; private set; }

        public HealthMeasurements()
        {
        }

        public HealthMeasurements(float weight, int bloodPressureUpper, int bloodPressureLower, int heartbeat, float temperature, float bloodSugarLevel)
        {
            Validation(weight, bloodPressureUpper, bloodPressureLower, heartbeat, temperature, bloodSugarLevel);
            Weight = weight;
            BloodPressureUpper = bloodPressureUpper;
            BloodPressureLower = bloodPressureLower;
            Heartbeat = heartbeat;
            Temperature = temperature;
            BloodSugarLevel = bloodSugarLevel;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Weight;
            yield return BloodPressureUpper;
            yield return BloodPressureLower;
            yield return Heartbeat;
            yield return Temperature;
            yield return BloodSugarLevel;
        }

        private void Validation(float weight, int bloodPressureUpper, int bloodPressureLower, int heartbeat, float temperature, float bloodSugarLevel)
        {
            if (weight <= 0)
            {
                throw new Exception("Value cannot be less than 0.");
            }
            if (bloodPressureUpper <= 0)
            {
                throw new Exception("Value cannot be less than 0.");
            }
            if (bloodPressureLower <= 0)
            {
                throw new Exception("Value cannot be less than 0.");
            }
            if (heartbeat <= 0)
            {
                throw new Exception("Value cannot be less than 0.");
            }
            if (temperature <= 0)
            {
                throw new Exception("Value cannot be less than 0.");
            }
            if (bloodSugarLevel <= 0)
            {
                throw new Exception("Value cannot be less than 0.");
            }
        }
    }
}
