using System.Collections.Generic;

namespace HospitalLibrary.Core.Appointment
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(string id);
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(Appointment appointment);
        Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc);
    }
}
