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

        public void Create(CreatePatientHealthMeasurementsDTO dto)
        {
            var phm = new PatientHealthMeasurements(dto);
            _repository.Create(phm);
        }
        public void Update(PatientHealthMeasurements phm)
        {
            _repository.Update(phm);
        }
        public void Delete(PatientHealthMeasurements phm)
        {
            _repository.Delete(phm);
        }
    }
}
