﻿using HospitalLibrary.Core.Appointment.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class AppointmentAdapter
    {
        public static Appointment CreateAppointmentDTOToAppointment(CreateAppointmentDTO appDTO)
        {
            Appointment app = new Appointment();
            app.DoctorId = "DOC1";
            app.PatientId = appDTO.patientId;
            string DAT = appDTO.startDate + " " + appDTO.startTime + ":00";
            app.Start = Convert.ToDateTime(DAT);
            app.RoomId = appDTO.roomId;
            app.Status = AppointmentStatus.Scheduled;
            return app;
        }

        public static ViewAllAppointmentsDTO AppointmentToViewAllAppointmentsDTO(Appointment appointment)
        {
            ViewAllAppointmentsDTO appointmentDto = new ViewAllAppointmentsDTO();

            appointmentDto.Id = appointment.Id;
            appointmentDto.PatientId = appointment.PatientId;
            appointmentDto.RoomNumber = appointment.Room.Number;
            appointmentDto.Start = appointment.Start.ToString("yyyy/MM/dd H:mm:ss");
            appointmentDto.Status = appointment.Status;

            return appointmentDto;
        }
        
    }
}