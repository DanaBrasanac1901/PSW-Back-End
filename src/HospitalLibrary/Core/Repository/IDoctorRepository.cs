using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Core.Repository
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(string id);
        void Create(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
    }
}
