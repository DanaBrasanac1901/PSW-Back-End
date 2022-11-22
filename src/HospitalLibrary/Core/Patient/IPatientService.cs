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
        string GetDoctorWithLeastPatients();
        List<string> GetDoctorsWithMaxTwoMorePatients();
        void Register(Patient patient);
        void Activate(Patient patient);
        Patient CheckCreditentials(string username, string password);
        IEnumerable<string> GetDoctorsWithLeastPatients();
        int GetMinNumOfPatients(int minNumber);
        int GetMaxNumOfPatients();
        int NumberOfPatientsByDoctor(string doctorId);
        IEnumerable<string> DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber);
        object DoesEmailExist(string email);
        object CredentialsValidity(string email, string password);
    }
}
