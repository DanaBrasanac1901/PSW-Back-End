using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.UseCases
{
    public interface IScheduleAppointment
    {
        void Execute(string eventId, DateTime timestamp);

    }
}
