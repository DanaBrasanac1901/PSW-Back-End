using HospitalLibrary.Core.Doctor.DTOS;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public List<Doctor> GetAllDoctorsForRescheduleForUrgentVacation(Appointment.Appointment appointment)
        {
            List<Doctor> doctorList = new List<Doctor>();
            foreach (var doctor in GetAll())
            {
                if (CheckIfDoctorIsBusy(doctor, appointment.Start) == true)
                {
                    doctorList.Add(doctor);
                }
            }
            return doctorList;
        }

        public Boolean CheckIfDoctorIsBusy(Doctor doctor,DateTime start)
        {
            foreach (var app in doctor.Appointments)
            {
                if (app.Start.Equals(start))
                {
                    return false;
                }
            }
            return true;
        }

        public List<GetAppointmentsUrgentVacationDTO> GetAppointmentsUrgentVacation(GetDoctorsAppointmentsForUrgentVacationDTO parameters)
        {
            List<GetAppointmentsUrgentVacationDTO> returnList = new List<GetAppointmentsUrgentVacationDTO>();
            DoctorAdapter adapter = new DoctorAdapter();
            List<DateTime> timeRange = adapter.UrgentVacationParametersHandling(parameters);
            foreach (var app in _doctorRepository.GetById(parameters.id).Appointments.ToList())
            {
                if(app.Start >= timeRange[0] && app.Start <= timeRange[1])
                {
                    returnList.Add(adapter.AppointmentToGetAppointmentsUrgentVacationDTO(app));
                }
            }
            return returnList;
        }

        

        public List<DoctorToChangeUrgentVacationDTO> GetFreeDoctors(string startDate,string startTime)
        {
            List<DoctorToChangeUrgentVacationDTO> returnList = new List<DoctorToChangeUrgentVacationDTO>();
            DoctorAdapter adapter = new DoctorAdapter();
            foreach (var doc in _doctorRepository.GetAll())
            {
                if (CheckIfDoctorIsBusy(doc, DateTime.Parse( startDate + " " + startTime))== true)
                    returnList.Add(adapter.DoctorToDoctorToChangeUrgentVacationDTO(doc));
            }
            return returnList;
        }
    }
}
