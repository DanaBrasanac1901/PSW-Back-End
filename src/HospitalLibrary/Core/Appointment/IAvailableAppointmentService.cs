using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment
{
    public interface IAvailableAppointmentService
    {
        //bez prioriteta
        IEnumerable<Doctor.Doctor> GetDoctorsByDateAndSpecialty(DateTime date, Specialty specialty);

        List<Doctor.Doctor> GetDoctorsBySpecialty(Specialty specialty);

        //sa prioritetom

        IEnumerable<DateTime> FindAppointmentsWithSuggestions(DateTimeRange dateRange, Doctor.Doctor doctor, string priority);

        IEnumerable<DateTime> FindIdealAppointments(DateTimeRange dateRange, Doctor.Doctor doctor);

        IEnumerable<DateTime> AppointmentsWithDatePriority(DateTimeRange dateRange, Specialty specialty);

        List<DateTime> GetDoctorsAvailableAppointmentsForDate(Doctor.Doctor doctor, DateTime date);

        //anjino

        IEnumerable<AppointmentPatientDTO> GetForPatient(string patientId);
    }
}
