using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.Data;

namespace HospitalLibrary.Core.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PatientService(IPatientRepository patientRepository,IDoctorRepository doctorRepository)
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

        public List<string> GetDoctorsWithLeastPatients()
        {
            IEnumerable<Doctor.Doctor> doctors = _doctorRepository.GetAll();
            int minimalPatientNumber = GetMinNumOfPatients(GetMaxNumOfPatients(doctors), doctors);
            return DoctorsWithSimiliarNumOfPatients(minimalPatientNumber, minimalPatientNumber + 2);
        }

        public int GetMinNumOfPatients(int minNumber, IEnumerable<Doctor.Doctor> doctors)
        {
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

        public int GetMaxNumOfPatients(IEnumerable<Doctor.Doctor> doctors)
        {
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

        public List<string> DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber)
        {
            List<Doctor.Doctor> doctors = (List<Doctor.Doctor>)_doctorRepository.GetAll();
            doctors.RemoveAll(d => NumberOfPatientsByDoctor(d.Id) > maxNumber || NumberOfPatientsByDoctor(d.Id) < minNumber);
            List<string> doctorIds = new List<string>();
            foreach(Doctor.Doctor d in doctors)
            {
                doctorIds.Add(d.Id);
            }
            return doctorIds;

        }
    }
}
