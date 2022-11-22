using HospitalLibrary.Core.Doctor.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(string id);

        Doctor CheckCreditentials(string email, string password);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        DoctorsShiftDTO GetDoctorsShiftById(string id);
        Boolean IsAvailable(string id, DateTime time);
    }
}
