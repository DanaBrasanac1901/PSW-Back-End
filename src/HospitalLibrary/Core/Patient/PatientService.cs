using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient.DTOS;
using Microsoft.AspNetCore.Builder;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalLibrary.Core.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

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
        public Patient GetByEmail(string email)
        {
            return _patientRepository.GetByEmail(email);
        }
        public PatientDTO GetDTOByEmail(string email)
        {
            Patient patient = _patientRepository.GetByEmail(email);
            PatientDTO patientDTO = new PatientDTO(patient);
            if (patient.DoctorID != null)
            {
                Doctor.Doctor doctor = _doctorRepository.GetById(patient.DoctorID);
                patientDTO.ChosenDoctor = doctor.Name + " " + doctor.Surname;
            }
            else patientDTO.ChosenDoctor = "NONE";
            return patientDTO;
        }

        public void Create(Patient patient)
        {

            _patientRepository.Create(patient);
        }

        public void Register(Patient patient)
        {
            _patientRepository.Create(patient);
        }

   
        public void Update(Patient patient)
        {
            _patientRepository.Update(patient);
        }

        public void Delete(Patient patient)
        {
            _patientRepository.Delete(patient);
        }

        public IEnumerable<Doctor.Doctor> GetDoctorsWithLeastPatients()
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

        public int NumberOfPatientsByDoctor(int doctorId)
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

        public IEnumerable<Doctor.Doctor> DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber)
        {
            List<Doctor.Doctor> doctors = _doctorRepository.GetAll().ToList();
            doctors.RemoveAll(d => NumberOfPatientsByDoctor(d.Id) > maxNumber || NumberOfPatientsByDoctor(d.Id) < minNumber);
            
            List<Doctor.Doctor> availableDoctors = new List<Doctor.Doctor>();
            foreach(Doctor.Doctor d in doctors)
            {
                availableDoctors.Add(d);
            }
            return availableDoctors;

        }

        private List<PatientForAppointmentDTO> ReturnPatientsForAppointment(int doctorId)
        {
            List<PatientForAppointmentDTO> retList = new List<PatientForAppointmentDTO>(); 
            foreach (var pat in _patientRepository.GetAll())
            {
                if(pat.DoctorID == doctorId)
                {
                    retList.Add(PatientAdapter.PatientToPatientForAppointmentDTO(pat));
                }
            }
            return retList;
        }

        public List<PatientForAppointmentDTO> GetPatientsForDoctor(int doctorId)
        {
            return ReturnPatientsForAppointment(doctorId);
        }

        public PatientForReportDTO GetPatientForReport(int id)
        {
            return PatientAdapter.PatientToPatientForReportDTO(_patientRepository.GetById(id));
        }

        IEnumerable<int> IPatientService.DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber)
        {
            throw new System.NotImplementedException();
        }


        public List<string> GetAllAllergies()
        {
            List<string> result = new List<string>();
            foreach (var item in Enum.GetNames(typeof(Allergy)))
            {
                result.Add(item.ToString());
            }
            return result;
        }

        /*
        public Patient CheckCreditentials(string username, string password)
        {
            foreach(Patient p in GetAll())
            {
                if (p.Email == username)
                    if (p.Password == password)
                        return p;
                    else return null;
            }
            return null;
        }
        */
    }
}
