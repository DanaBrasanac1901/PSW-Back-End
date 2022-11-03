using HospitalLibrary.Core.Doctor.DTOS;
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

        public DoctorsShiftDTO GetDoctorsShiftById(string id)
        {
            Doctor doctor = _doctorRepository.GetById(id);
            DoctorAdapter adapter = new DoctorAdapter();
            return adapter.DoctorToDoctorsShiftDTO(doctor);
        }

        public Boolean IsAvailable(string doctorId, DateTime appointmentTime)
        {
            //DateTime appointment = DateTime.Parse(appointmentTime);
            Doctor doc = GetById(doctorId);
            foreach (Appointment.Appointment a in doc.Appointments)
            {
                TimeSpan interval = a.Start - appointmentTime;
                if (Math.Abs(interval.Minutes) < 20)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
