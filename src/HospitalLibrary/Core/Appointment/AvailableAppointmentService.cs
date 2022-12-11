﻿using Castle.Core.Internal;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Room;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorModel = HospitalLibrary.Core.Doctor.Doctor;  // namespace used like a type, had to add an alias - anja

namespace HospitalLibrary.Core.Appointment
{
    public class AvailableAppointmentService : IAvailableAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IRoomRepository _roomRepository;

        public AvailableAppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }


        public IEnumerable<AppointmentPatientDTO> GetForPatient(string patientId)
        {
            IEnumerable<Appointment> appointments = _appointmentRepository.GetAllByPatient(patientId);
            List<AppointmentPatientDTO> result = new List<AppointmentPatientDTO>();
            foreach (Appointment appt in appointments)
            {
                AppointmentPatientDTO dto = new AppointmentPatientDTO(appt);
                DoctorModel doctor = _doctorRepository.GetById(appt.DoctorId);
                dto.DoctorName = doctor.Name + ' ' + doctor.Surname;

                result.Add(dto);
            }

            return result;

        }

        //prosledjujemo samo slobodne lekare tog dana i te specijalnosti
        public IEnumerable<Doctor.Doctor> GetDoctorsByDateAndSpecialty(DateTime date, Specialty specialty)
        {
            List<Doctor.Doctor> specializedDoctors = GetDoctorsBySpecialty(specialty);
            foreach (Doctor.Doctor doctor in specializedDoctors)
            {
                IEnumerable<AppointmentPatientDTO> appointments = GetDoctorsAvailableAppointmentsForDate(doctor, date);
                if (appointments.IsNullOrEmpty())
                {
                    specializedDoctors.Remove(doctor);
                }

            }

            return specializedDoctors;
        }

        //ovo je za obicno zakazivanje za pacijenta, prikaz svih lekara neke specijalizacije
        public List<Doctor.Doctor> GetDoctorsBySpecialty(Specialty specialty)
        {
            List<Doctor.Doctor> doctorsWithSpecialty = new List<Doctor.Doctor>();
            IEnumerable<Doctor.Doctor> allDoctors = _doctorRepository.GetAll();
            foreach (Doctor.Doctor doctor in allDoctors)
            {
                if (doctor.Specialty == specialty)
                {
                    doctorsWithSpecialty.Add(doctor);
                }
            }

            return doctorsWithSpecialty;
        }

        //ovo je za zakazivanje s prioritetima za pacijenta, osnovna fja
        public IEnumerable<AppointmentPatientDTO> FindAppointmentsWithSuggestions(DateTimeRange dateRange, Doctor.Doctor doctor, string priority)
        {
            IEnumerable<AppointmentPatientDTO> idealAppointments = FindIdealAppointments(dateRange, doctor);
            if (!idealAppointments.Any <AppointmentPatientDTO>())
            {
                if (priority == "DOCTOR")
                {
                    DateTimeRange newDateRange = GetNewDateRange(dateRange);
                    return FindIdealAppointments(newDateRange, doctor);
                }
                else if (priority == "DATE")
                {
                    return AppointmentsWithDatePriority(dateRange, doctor.Specialty);

                }
            }
            return null;
        }


        //kada su oba uslova ispunjena, i lekar i datumi 
        //koristimo i kad nije idealno n ego kad je lekar prioritet jer samo trazimo s novim rangeom
        public IEnumerable<AppointmentPatientDTO> FindIdealAppointments(DateTimeRange dateRange, Doctor.Doctor doctor)
        {
            List<AppointmentPatientDTO> allAppointments = new List<AppointmentPatientDTO>();
            DateTime dateIterator = dateRange.Start;

            while (dateIterator < dateRange.End)
            {
                allAppointments.AddRange(GetDoctorsAvailableAppointmentsForDate(doctor, dateIterator));
                dateIterator = dateIterator.AddDays(1);
            }
            return allAppointments;
        }

        //samo prosirimo range kad nije uslob ispunjen
        public DateTimeRange GetNewDateRange(DateTimeRange dateRange)
        {
            DateTime newStart = dateRange.Start.AddDays(-5);
            DateTime newEnd = dateRange.End.AddDays(5);
            return new DateTimeRange(newStart, newEnd);
        }

        //nisu oba ispunjena, nadju se za isti daterange lekari sa istom specijalnoscu
        public IEnumerable<AppointmentPatientDTO> AppointmentsWithDatePriority(DateTimeRange dateRange, Specialty specialty)
        {
            DateTime dateIterator = dateRange.Start;
            List <Doctor.Doctor> doctors = GetDoctorsBySpecialty(specialty);
            List<AppointmentPatientDTO> appointments = new List<AppointmentPatientDTO>();

            while (dateIterator < dateRange.End)
            {
               foreach(Doctor.Doctor doctor in doctors)
                {
                    appointments.AddRange(GetDoctorsAvailableAppointmentsForDate(doctor, dateIterator));
                }

                dateIterator = dateIterator.AddDays(1);
            }
            return appointments;
        }

        //klasika idemo po terminima fiksno vreme je 20 min sve dok ne dodjemo do kraja radnog vremena
        public IEnumerable<AppointmentPatientDTO> GetDoctorsAvailableAppointmentsForDate(Doctor.Doctor doctor, DateTime date)
        {
            DateTime timeIterator = new DateTime(date.Year, date.Month, date.Day, doctor.StartWorkTime, 0, 0);
            DateTime endPoint = new DateTime(date.Year, date.Month, date.Day, doctor.EndWorkTime, 0, 0);
            List<AppointmentPatientDTO> termini = new List<AppointmentPatientDTO>();
            
            while (timeIterator < endPoint)
            {
                GeneratingDTOs(doctor, date, timeIterator, termini);
                timeIterator = timeIterator.AddMinutes(20);
            }

            return termini;
        }

        //cisto pravljenje dto
        private static void GeneratingDTOs(DoctorModel doctor, DateTime date, DateTime startTime, List<AppointmentPatientDTO> termini)
        {
            DateTime timeSlotEnd = startTime.AddMinutes(20);
            if (doctor.IsAvailable(startTime, timeSlotEnd))
            {
                //DateTime.Now.ToString("dddd, dd MMMM yyyy") primer Friday, 29 May 2015
                termini.Add(new AppointmentPatientDTO { DoctorName = doctor.Name+' '+doctor.Surname, StartDate = date.ToString("dddd, dd MMMM yyyy"), StartTime = startTime.ToString("hh:mm tt"), RoomNumber = doctor.RoomId.ToString() });
            }
           
        }
    }
}
