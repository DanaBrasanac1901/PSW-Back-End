using System.Collections.Generic;

namespace HospitalLibrary.Core.Patient
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Create(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
        //Patient CheckCreditentials(string username, string password);
        IEnumerable<Doctor.Doctor> GetDoctorsWithLeastPatients();
        int GetMinNumOfPatients(int minNumber);
        int GetMaxNumOfPatients();
        int NumberOfPatientsByDoctor(string doctorId);
        IEnumerable<Doctor.Doctor> DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber);
        void Register(Patient patient);
        Patient GetByEmail(string email);
    }
}
