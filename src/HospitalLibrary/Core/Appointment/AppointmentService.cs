using HospitalLibrary.Core.Appointment;
//using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc)
        {
            return _appointmentRepository.SetDoctorAppointment(doc);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(string id)
        {
            return _appointmentRepository.GetById(id);
        }

        public void Create(Appointment appointment)
        {
            Appointment app = new Appointment(appointment.Id, appointment.DoctorId, appointment.PatientId, appointment.Start, appointment.RoomId); ;
            _appointmentRepository.Create(app);
        }

        public void Update(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAllByDoctor(string id)
        {
            return _appointmentRepository.GetAllByDoctor(id);
        }
    }
}
