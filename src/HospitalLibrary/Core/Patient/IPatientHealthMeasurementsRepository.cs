using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public interface IPatientHealthMeasurementsRepository
    {
        IEnumerable<PatientHealthMeasurements> GetAll();
        PatientHealthMeasurements GetById(int id);
        void Create(PatientHealthMeasurements patientHealthMeasurements);
        void Update(PatientHealthMeasurements patientHealthMeasurements);
        void Delete(PatientHealthMeasurements patientHealthMeasurements);
    }
}
