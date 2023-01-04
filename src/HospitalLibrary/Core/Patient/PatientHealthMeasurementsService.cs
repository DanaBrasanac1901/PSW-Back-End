using HospitalLibrary.Core.Patient.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class PatientHealthMeasurementsService : IPatientHealthMeasurementsService
    {
        private readonly IPatientHealthMeasurementsRepository _repository;

        public PatientHealthMeasurementsService(IPatientHealthMeasurementsRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<PatientHealthMeasurements> GetAll()
        {
            return _repository.GetAll();
        }
        public PatientHealthMeasurements GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Create(SubmitPatientHealthMeasurementsDTO dto)
        {
            if(int.TryParse(dto.PatientId, out int patientId) && float.TryParse(dto.Weight, out float weight) &&
               int.TryParse(dto.BloodPressureUpper, out int bloodPressureUpper) &&
               int.TryParse(dto.BloodPressureLower, out int bloodPressureLower) &&
               int.TryParse(dto.Heartbeat, out int heartbeat) &&
               float.TryParse(dto.Temperature, out float temperature) &&
               float.TryParse(dto.BloodSugarLevel, out float bloodSugarLevel))
            {
                var phm = new PatientHealthMeasurements(patientId, weight, bloodPressureUpper, bloodPressureLower, heartbeat, temperature, bloodSugarLevel);
                _repository.Create(phm);
            }
            else
            {
                throw new ArgumentException("Inputs must be numbers.");
            }
        }
        public void Update(PatientHealthMeasurements phm)
        {
            _repository.Update(phm);
        }
        public void Delete(PatientHealthMeasurements phm)
        {
            _repository.Delete(phm);
        }
        public IEnumerable<PatientHealthMeasurements> GetPatientHealthMeasurements(int id)
        {
            DateTime kita = DateTime.Now.AddDays(-30);
            //DateTime checkDateTime = new DateTime();
            //uzmi sve unete podatke od trazenog pacijenta koji su u proteklih mesec dana
            return _repository.GetAll().Where(phm => phm.MeasurementTime >= kita && phm.PatientId == id).ToList();

        }
    }
}
