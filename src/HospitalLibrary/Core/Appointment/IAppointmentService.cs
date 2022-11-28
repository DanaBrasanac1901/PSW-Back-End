using HospitalLibrary.Core.Appointment.DTOS;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Appointment
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(string id);
        string Create(CreateAppointmentDTO appointment);

        void Delete(string appId);

        void Update(RescheduleAppointmentDTO appointment);

        Boolean IsAvailable(Appointment appointment);

        Boolean CheckIfAppointmentIsSetInFuture(DateTime dateToCheck);

        IEnumerable<ViewAllAppointmentsDTO> GetAllByDoctor(string id);

        Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc);

       void UpdateFinishedAppointments();

        RescheduleAppointmentDTO GetAppoitnemtnToReschedule(string id);

        IEnumerable<Appointment> GetAvailableForDoctor();
        IEnumerable<Appointment> GetAvailableForDoctorAndDate();
        IEnumerable<Appointment> GetAvailableForDate();
    }
}
