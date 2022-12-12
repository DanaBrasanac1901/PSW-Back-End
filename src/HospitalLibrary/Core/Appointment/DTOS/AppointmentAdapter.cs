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

        public static RescheduleAppointmentDTO AppointmentToRescheduleAppointmentDTO(Appointment appointment)
        {
            RescheduleAppointmentDTO dto = new RescheduleAppointmentDTO();
            dto.id = appointment.Id;
            dto.patientId = appointment.PatientId;
            dto.date = appointment.Start.Year + "-" + appointment.Start.Month + "-" + appointment.Start.Day;
            dto.time = appointment.Start.Hour + ":" + appointment.Start.Minute;
            return dto;
        }

        private static DateTime createTime(RescheduleAppointmentDTO dto)
        {
            string timeParse = dto.date + " " + dto.time;
            DateTime newStartTime = Convert.ToDateTime(timeParse);
            return newStartTime;
        }

        public static Appointment RescheduleAppointmentDTOToAppointment(RescheduleAppointmentDTO dto,Appointment app)
        {
            string timeParse = dto.date + " " + dto.time;
            DateTime newStartTime = Convert.ToDateTime(timeParse);
            app.Start = createTime(dto);
            return app;
        }

        public static AppointmentForReportDTO AppointmentToAppointmentForReportDTO(Appointment app)
        {
            AppointmentForReportDTO dto = new AppointmentForReportDTO();
            dto.id = app.Id;
            dto.patientId = app.PatientId;
            dto.doctorId = app.DoctorId;
            return dto;
        }
    }
}
