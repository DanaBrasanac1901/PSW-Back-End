using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
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
            UpdateFinishedAppointments();
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

        public void Create(CreateAppointmentDTO appointmentDTO)
        {
            Appointment app = AppointmentAdapter.CreateAppointmentDTOToAppointment(appointmentDTO);
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


        public IEnumerable<ViewAllAppointmentsDTO> GetAllByDoctor(string id)
        {
            IEnumerable<Appointment> doctorsApointments = _appointmentRepository.GetAllByDoctor(id);
            List<ViewAllAppointmentsDTO> appointmentsDTOs = new List<ViewAllAppointmentsDTO>();
            foreach(Appointment a in doctorsApointments)
                appointmentsDTOs.Add(AppointmentAdapter.AppointmentToViewAllAppointmentsDTO(a));


            return appointmentsDTOs;
        }

        public void UpdateFinishedAppointments()
        {
            List<Appointment> appointments = (List<Appointment>)_appointmentRepository.GetAll();

            TimeSpan difference;
            DateTime currentTime = DateTime.Now;

            foreach (Appointment appointment in appointments)
            {
                difference = currentTime.Subtract(appointment.Start);
                if (difference.TotalMinutes > 20)
                {
                    appointment.Status = AppointmentStatus.Finished;
                    _appointmentRepository.Update(appointment);
                }
            }
        }
    }
}
