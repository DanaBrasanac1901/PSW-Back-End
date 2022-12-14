using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.PatientAppointmentCancelation
{
    public interface IPatientAppointmentCancelationService
    {
        IEnumerable<PatientAppointmentCancelation> GetAll();
        void Create(string patientId);
    }
}
