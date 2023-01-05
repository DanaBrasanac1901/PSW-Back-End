using System.Collections.Generic;

namespace HospitalLibrary.Core.Patient
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Create(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
    }
}
