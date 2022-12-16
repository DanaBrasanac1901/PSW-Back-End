using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.AppointmentCancelation
{
    public class AppointmentCancelation
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public DateTime CancelationDate { get; set; }

        public AppointmentCancelation(string patientId, DateTime cancelationDate)
        {
            this.PatientId = patientId;
            this.CancelationDate = cancelationDate;
        }
    }
}
