using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Appointment.DTOS
{
    public class AvailableAppointmentsDTO
    {
        public DateTimeRange DateRange { get; set; }
        public Doctor.Doctor Doctor { get; set; }

        public DateTime Date { get; set; }

        public AvailableAppointmentsDTO() { }

        public AvailableAppointmentsDTO(DateTimeRange dateTimeRange, Doctor.Doctor doctor)
        {
            DateRange = dateTimeRange;
            Doctor = doctor;
        }

        public AvailableAppointmentsDTO(DateTime date, Doctor.Doctor doctor)
        {
            Date = date;
            Doctor = doctor;
        }



    }
}
