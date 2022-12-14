using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Vacation;
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
        private readonly IAppointmentRepository _appointmentRepository;
        DoctorAdapter adapter = new DoctorAdapter();

        public DoctorService(IDoctorRepository doctorRepository)
        {
            
            _doctorRepository = doctorRepository;
        }

        public DoctorService(IDoctorRepository doctorRepository,IVacationRepository vacationRepository, IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
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

        //public List<Doctor> GetAllDoctorsForRescheduleForUrgentVacation(Appointment.Appointment appointment)
        //{
        //    List<Doctor> doctorList = new List<Doctor>();
        //    foreach (var doctor in GetAll())
        //    {
        //        if (CheckIfDoctorIsBusy(doctor, appointment.Start) == true)
        //        {
        //            doctorList.Add(doctor);
        //        }
        //    }
        //    return doctorList;
        //}

        public Boolean CheckIfDoctorIsBusy(ICollection<Appointment.Appointment> apps,DateTime start)
        {
            foreach (var app in apps)
            {
                if (app.Start.Equals(start))
                {
                    return false;
                }
            }
            return true;
        }

        public List<GetAppointmentsUrgentVacationDTO> ReturnListGetAppointmentsUrgentVacation(ICollection<Appointment.Appointment> apps,
            List<DateTime> startAndEnd)
        {
            List<GetAppointmentsUrgentVacationDTO> returnList = new List<GetAppointmentsUrgentVacationDTO>();
            foreach (var app in apps)
            {
                if (app.Start >= startAndEnd[0] && app.Start <= startAndEnd[1])
                {
                    returnList.Add(adapter.AppointmentToGetAppointmentsUrgentVacationDTO(app));
                }
            }
            return returnList;
        }

        public List<GetAppointmentsUrgentVacationDTO> GetAppointmentsUrgentVacation(GetDoctorsAppointmentsForUrgentVacationDTO parameters)
        {
            List<DateTime> timeRange = adapter.UrgentVacationParametersHandling(parameters);
            return ReturnListGetAppointmentsUrgentVacation(_doctorRepository.GetById(parameters.id).Appointments, timeRange);
        }

        

        public List<DoctorToChangeUrgentVacationDTO> GetFreeDoctors(string startDate,string startTime)
        {
            List<DoctorToChangeUrgentVacationDTO> returnList = new List<DoctorToChangeUrgentVacationDTO>();
            
            foreach (var doc in _doctorRepository.GetAll())
            {
                if (CheckIfDoctorIsBusy(doc.Appointments, DateTime.Parse( startDate + " " + startTime))== true)
                    returnList.Add(adapter.DoctorToDoctorToChangeUrgentVacationDTO(doc));
            }
            return returnList;
        }

        public List<string> GetFreeSpecialtyDoctors(string date, int specialty)
        {
            List<string> ret = new List<string>();
            List<Appointment.Appointment> app = new List<Appointment.Appointment>(_appointmentRepository.GetAll());
            DateTime parsed = DateTime.Parse(date);
            foreach (Doctor d in _doctorRepository.GetAll().Where(doc => (int)doc.Specialty == specialty))
            {
                if((d.EndWorkTime - d.StartWorkTime)*3 > (app.Where(a => a.DoctorId == d.Id && a.Status == AppointmentStatus.Scheduled && a.Start.Year == parsed.Year && a.Start.Month == parsed.Month && a.Start.Day == parsed.Day)).Count())
                {
                    ret.Add(d.Id);
                }
            }
            return ret;
        }

        public List<string> GetSpecialtyDoctors(int specialty)
        {
            List<string> ret = new List<string>();
            foreach (Doctor d in _doctorRepository.GetAll().Where(doc => (int)doc.Specialty == specialty))
            {
                ret.Add(d.Id);
            }
            return ret;
        }
    }
}
