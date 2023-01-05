using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.Enums;
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


        IEnumerable<ViewAllAppointmentsDTO> GetAllByDoctor(int id);

        Doctor.Doctor SetDoctorAppointment(Doctor.Doctor doc);

        void UpdateFinishedAppointments();

        RescheduleAppointmentDTO GetAppoitnemtnToReschedule(string id);

        void ChangeDoctorForAppointment(int doctorId,string appointmentId);


        AppointmentForReportDTO GetAppointmentForReport(string appId);
        IEnumerable<Patient.Patient> GetDoctorsPatients(int id);

    }
}
