using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor
{
    public class DoctorService: IDoctorService

    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetById(string id)
        {
            return _doctorRepository.GetById(id);
        }

        public void Create(Doctor doctor)
        {
            _doctorRepository.Create(doctor);
        }

        public void Update(Doctor doctor)
        {
            _doctorRepository.Update(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctorRepository.Delete(doctor);
        }

        //funkcija za proveru

        public Boolean IsAvailable(string doctorId, string appointmentTime)
        {
            //parse string to datetime
            DateTime dt = new DateTime();
            Doctor doc = _doctorRepository.GetById(doctorId);
            //funkcija za proveru
            return false;
        }
    }
}
