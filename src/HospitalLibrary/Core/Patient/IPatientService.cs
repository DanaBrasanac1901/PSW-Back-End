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
        IEnumerable<string> GetDoctorsWithLeastPatients();
        int GetMinNumOfPatients(int minNumber, IEnumerable<Doctor.Doctor> doctors);
        int GetMaxNumOfPatients(IEnumerable<Doctor.Doctor> doctors);
        int NumberOfPatientsByDoctor(string doctorId);
        IEnumerable<string> DoctorsWithSimiliarNumOfPatients(int minNumber, int maxNumber);
    }
}
