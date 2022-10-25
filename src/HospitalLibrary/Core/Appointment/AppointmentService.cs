using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
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
            _appointmentRepository.Create(appointment);
        }

        public void Update(Appointment appointment)
        {
            _appointmentRepository.Update(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentRepository.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAllByDoctor(string id){
            return _appointmentRepository.GetAllByDoctor(id);
        }
    }
}