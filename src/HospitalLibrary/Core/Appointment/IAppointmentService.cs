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

        void ChangeDoctorForAppointment(string doctorId,string appointmentId);

        void PatientCancelsAppointment(string appointmentId);
    }
}
