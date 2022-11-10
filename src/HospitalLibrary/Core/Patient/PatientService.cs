using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Patient;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public void Create(Patient patient)
        {
            _patientRepository.Create(patient);
        }
        public void Register(Patient patient)
        {
            patient.Active = false;
            _patientRepository.Create(patient);
        }
        public void Activate(Patient patient)
        {
            patient.Active = true;
            _patientRepository.Update(patient);
        }
        public void Update(Patient patient)
        {
            _patientRepository.Update(patient);
        }

        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
        }
    }
}
