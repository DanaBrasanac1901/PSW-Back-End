using HospitalLibrary.Core.Patient.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public interface IPatientHealthMeasurementsService
    {
        IEnumerable<PatientHealthMeasurements> GetAll();
        PatientHealthMeasurements GetById(int id);
        void Create(CreatePatientHealthMeasurementsDTO dto);
        void Update(PatientHealthMeasurements patientHealthMeasurements);
        void Delete(PatientHealthMeasurements patientHealthMeasurements);
    }
}
