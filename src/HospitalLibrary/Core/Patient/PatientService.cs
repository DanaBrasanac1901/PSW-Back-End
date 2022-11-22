using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalLibrary.Core.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public PatientService(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
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

        public IEnumerable<string> GetDoctorsWithLeastPatients()
        {
            int minimalPatientNumber = GetMinNumOfPatients(GetMaxNumOfPatients());
            return DoctorsWithSimiliarNumOfPatients(minimalPatientNumber, minimalPatientNumber + 2);
        }

        public int GetMinNumOfPatients(int minNumber)
        {
            IEnumerable<Doctor.Doctor> doctors = _doctorRepository.GetAll();
            foreach (Doctor.Doctor doctor in doctors)
            {
                int personalNumber = NumberOfPatientsByDoctor(doctor.Id);
                if (personalNumber <= minNumber)
                {
                    minNumber = personalNumber;
                }
            }
            return minNumber;
        }

        public int GetMaxNumOfPatients()
        {
            IEnumerable<Doctor.Doctor> doctors = _doctorRepository.GetAll();
            int maxNumber = 0;
            foreach (Doctor.Doctor doctor in doctors)
            {
                int personalNumber = NumberOfPatientsByDoctor(doctor.Id);
                if (personalNumber >= maxNumber)
                {
                    maxNumber = personalNumber;
                }
            }
            return maxNumber;
        }

        public int NumberOfPatientsByDoctor(string doctorId)
        {
            IEnumerable<Patient> patients = GetAll();
            int personalNumber = 0;
            foreach (Patient patient in patients)
            {
                if (patient.DoctorID.Equals(doctorId))
                {
                    personalNumber++;
                }
            }
            return personalNumber;
        }

        public IEnumerable<string> DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber)
        {
            List<Doctor.Doctor> doctors = _doctorRepository.GetAll().ToList();
            doctors.RemoveAll(d => NumberOfPatientsByDoctor(d.Id) > maxNumber || NumberOfPatientsByDoctor(d.Id) < minNumber);
            
            List<string> doctorIds = new List<string>();
            foreach(Doctor.Doctor d in doctors)
            {
                doctorIds.Add(d.Id);
            }
            return doctorIds;

        }


        public object DoesEmailExist(string email)
        {
            foreach (Patient patient in GetAll()) {
                if (patient.Email.Equals(email)) return patient;
            }
            return null;
        }

        public object CredentialsValidity(string email, string password)
        {
            foreach (Patient patient in GetAll())
            {
                if (patient.Email.Equals(email))
                {
                   if (patient.Password.Equals(password)) return patient;
                }
            }

            return null;
        }
        
    }
}
