using HospitalLibrary.Core.Appointment.DTOS;
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
            app.Id = appDTO.id;
            app.DoctorId = appDTO.doctorId;
            app.PatientId = appDTO.patientId;
            app.Start = DateTime.Now;
            app.RoomId = appDTO.roomId;
            app.Status = AppointmentStatus.Scheduled;
            return app;
        }

        public static ViewAllAppointmentsDTO AppointmentToViewAllAppointmentsDTO(Appointment appointment)
        {
            ViewAllAppointmentsDTO appointmentDto = new ViewAllAppointmentsDTO();

            appointmentDto.Id = appointment.Id;
            appointmentDto.PatientId = appointment.PatientId;
            appointmentDto.RoomId = appointment.RoomId.ToString();
            appointmentDto.Start = appointment.Start.ToString();
            appointmentDto.Status = appointment.Status;

            return appointmentDto;
        }
        
    }
}
