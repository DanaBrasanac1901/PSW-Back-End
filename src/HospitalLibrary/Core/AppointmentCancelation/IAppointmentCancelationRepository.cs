using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.AppointmentCancelation
{
    public interface IAppointmentCancelationRepository
    {
        IEnumerable<AppointmentCancelation> GetAll();
        AppointmentCancelation GetById(int id);
        void Create(AppointmentCancelation appointment);
    }
}
