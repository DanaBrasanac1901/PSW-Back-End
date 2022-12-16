using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.AppointmentCancelation
{
    public interface IAppointmentCancelationService
    {
        IEnumerable<AppointmentCancelation> GetAll();
        AppointmentCancelation GetById(int id);
        void Create(string patientId, DateTime time);
        IEnumerable<string> GetMaliciousPatients();
    }
}
