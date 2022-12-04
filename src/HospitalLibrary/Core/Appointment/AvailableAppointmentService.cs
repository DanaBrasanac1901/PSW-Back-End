using Castle.Core.Internal;
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
        private readonly IAppointmentRepository _appointmentRepositoryMock;
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

        //ovo je za obicno zakazivanje za pacijenta, prikaz svih lekara te specijalizacije koji su slobodni tog dana
        public IEnumerable<Doctor.Doctor> GetDoctorsByDateAndSpecialty(DateTime date, Specialty specialty)
        {
            List<Doctor.Doctor> specializedDoctors = GetDoctorsBySpecialty(specialty);
            foreach (Doctor.Doctor doctor in specializedDoctors)

                if (GetDoctorsAvailableAppointmentsForDate(doctor,date).IsNullOrEmpty())
                {
                    specializedDoctors.Remove(doctor);
                }

            return specializedDoctors;
        }


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
        public IEnumerable<DateTime> FindAppointmentsWithSuggestions(DateTimeRange dateRange, Doctor.Doctor doctor, string priority)
        {
            IEnumerable<DateTime> idealAppointments = FindIdealAppointments(dateRange, doctor);
            if (idealAppointments.Any<DateTime>())
            {
                if (priority == "DOCTOR")
                {
                    DateTimeRange newDateRange = GetNewDateRange(dateRange);
                    return AppointmentsWithDoctorPriority(newDateRange, doctor);
                }
                else if (priority == "DATE")
                {
                    return AppointmentsWithDatePriority(dateRange, doctor.Specialty);

                }


            }


            return null;
        }


        //kada su oba uslova ispunjena, i lekar i datumi 
        public IEnumerable<DateTime> FindIdealAppointments(DateTimeRange dateRange, Doctor.Doctor doctor)
        {

            return null;
        }

        //nisu oba ispunjena, mora da se nadje za istog doktora sa prosirenim datumima
        public IEnumerable<DateTime> AppointmentsWithDoctorPriority(DateTimeRange dateRange, Doctor.Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public DateTimeRange GetNewDateRange(DateTimeRange dateRange)
        {
            DateTime newStart = dateRange.Start.AddDays(-5);
            DateTime newEnd = dateRange.End.AddDays(5);
            return new DateTimeRange(newStart, newEnd);
        }

        //nisu oba ispunjena, nadje se za isti daterange lekari sa istom specijalnoscu
        public IEnumerable<DateTime> AppointmentsWithDatePriority(DateTimeRange dateRange, Specialty specialty)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DateTime> GetDoctorsAvailableAppointmentsForDate(Doctor.Doctor doctor, DateTime date)
        {
            DateTime startingPoint = new DateTime(date.Year, date.Month, date.Day, doctor.StartWorkTime, 0, 0);
            DateTime endPoint = new DateTime(date.Year, date.Month, date.Day, doctor.EndWorkTime, 0, 0);
            List<DateTime> termini = new List<DateTime>();

            while (startingPoint < endPoint)
            {
                DateTime timeSlotEndPoint = startingPoint;
                timeSlotEndPoint.AddMinutes(20);
                if (doctor.IsAvailable(startingPoint, timeSlotEndPoint))
                {
                    termini.Add(startingPoint);
                }

                startingPoint.AddMinutes(20);

            }

            return termini;
        }

    }
}
