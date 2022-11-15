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
    }
}
