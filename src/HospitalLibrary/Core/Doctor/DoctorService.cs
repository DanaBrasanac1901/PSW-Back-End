using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Consiliums.DTO;
using HospitalLibrary.Core.Doctor.DTOS;

﻿using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Enums;
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

        public Doctor GetById(int id)
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

        public DoctorsShiftDTO GetDoctorsShiftById(int id)
        {
            Doctor doctor = _doctorRepository.GetById(id);
            DoctorAdapter adapter = new DoctorAdapter();
            return adapter.DoctorToDoctorsShiftDTO(doctor);
        }

        public Boolean IsAvailable(int doctorId, DateTime appointmentTime)
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

        public List<Doctor> GetAvailableBySpecialty(int specialty, DateTimeRange consiliumInterval)
        {
            List<Doctor> doctorsBySpecialty = _doctorRepository.GetBySpecialty(specialty);

            List<Doctor> availableDoctors = new List<Doctor>();
            foreach(Doctor doctor in doctorsBySpecialty)
            {
                if (doctor.IsAvailable(consiliumInterval.Start, consiliumInterval.End))
                    availableDoctors.Add(doctor);
            }
            return availableDoctors;
        }

        public List<GetAppointmentsUrgentVacationDTO> GetAppointmentsUrgentVacation(GetDoctorsAppointmentsForUrgentVacationDTO parameters)
        {
            List<DateTime> timeRange = adapter.UrgentVacationParametersHandling(parameters);
            return ReturnListGetAppointmentsUrgentVacation(_doctorRepository.GetById(parameters.id).Appointments, timeRange);
        }

        public List<Doctor> AvailableByEachSpecialty(string specialties, DateTimeRange consiliumInterval)
        {
            string[] requiredSpecialties = specialties.Split(',');

            List<Doctor> availableDoctors = new List<Doctor>();
            
            foreach(string specialty in requiredSpecialties)
            {
                int currentSpecialty = Int32.Parse(specialty);
                List<Doctor> availableBySpecialty = GetAvailableBySpecialty(currentSpecialty, consiliumInterval);
                if (availableBySpecialty.Count == 0)
                    return null;
                availableDoctors.AddRange(availableBySpecialty);
            }
            return availableDoctors;
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


        public List<int> GetFreeSpecialtyDoctors(string date, int specialty)
        {
            List<int> ret = new List<int>();
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

        public List<int> GetSpecialtyDoctors(int specialty)
        {
            List<int> ret = new();
            foreach (Doctor d in _doctorRepository.GetAll().Where(doc => (int)doc.Specialty == specialty))
            {
                ret.Add(d.Id);
            }
            return ret;
        }

        public bool AreAvailableForConsilium(List<Doctor> neededDoctors, DateTimeRange consiliumInterval)
        {

            foreach(Doctor doctor in neededDoctors)
            {
                if (!doctor.IsAvailable(consiliumInterval.Start, consiliumInterval.End))
                    return false;
            }

            return true;
        }

        private IEnumerable<Doctor> StringToIntIds(string doctorIds)
        {
            List<Doctor> doctors = new List<Doctor>();
            string[] doctorIdsSplit = doctorIds.Split(",");
            foreach (string id in doctorIdsSplit)
            {
                int.TryParse(id, out int docId);
                doctors.Add(_doctorRepository.GetById(docId));
            }
            return doctors;
        }

        public IEnumerable<Doctor> GetByIds(string doctorIds)
        {
            return StringToIntIds(doctorIds);
        }
        public List<Doctor> GetBySpecialty(string specialty)
        {
            Specialty spec;
            bool isSuccesful=Specialty.TryParse(specialty,out spec);
            List<Doctor> returnList = new List<Doctor>();

            if (isSuccesful)
            {
                foreach (Doctor doctor in GetAll())
                {
                    if (doctor.Specialty.Equals(spec)) returnList.Add(doctor);
                }
            }
            return returnList;
        }
    }
}
