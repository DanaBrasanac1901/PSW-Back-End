using HospitalLibrary.Core.Appointment;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Appointment
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(string id);
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
        IEnumerable<Appointment> GetAllByDoctor(string id);
        IEnumerable<Appointment> GetAllByPatient(string id);
        Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc);
    }
}
