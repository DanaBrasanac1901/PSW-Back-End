using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class AvailableAppointmentsDTO
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string RoomNumber { get; set; }
        public string Status { get; set; }
        public DateTimeRange DateRange { get; set; }
        public Doctor.Doctor Doctor { get; set; }

        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string TimeString { get; set; }

        public AvailableAppointmentsDTO() { }

        public AvailableAppointmentsDTO(DateTimeRange dateTimeRange, Doctor.Doctor doctor)
        {
            DateRange = dateTimeRange;
            Doctor = doctor;
        }

        public AvailableAppointmentsDTO(string date, Doctor.Doctor doctor)
        {
            Date = DateTime.Parse(date);
            Doctor = doctor;
            DateRange=new DateTimeRange(Date,Date);
        }

        public AvailableAppointmentsDTO(Appointment appointment)
        {
            DateRange = new DateTimeRange(Date, Date);
            PatientId = appointment.PatientId;
            DoctorId = appointment.DoctorId;
            Date = appointment.Start;
            DateString = Date.ToString("dddd, dd MMMM yyyy");
            TimeString = appointment.Start.TimeOfDay.ToString();
            Status = appointment.Status.ToString();
            RoomNumber = appointment.RoomId.ToString();
        }

        public CreateAppointmentDTO toCreateDTO()
        {

            DateTime _datetime = DateTime.Parse(DateString + ' ' + TimeString);

            string pattern = @"\d{2}:\d{2}";
            Regex rg = new Regex(pattern);
            MatchCollection cleanedTime = rg.Matches(_datetime.TimeOfDay.ToString());

            CreateAppointmentDTO dto = new CreateAppointmentDTO 
                                          { appointmentDuration = 20,
                                            doctorId = DoctorId, 
                                            patientId = PatientId,
                                            startDate = _datetime.ToShortDateString(),
                                            startTime = cleanedTime[0].Value,
                                            status = "Scheduled",
                                            roomId = int.Parse(RoomNumber)
                                            };
            return dto;
        }



    }
}
