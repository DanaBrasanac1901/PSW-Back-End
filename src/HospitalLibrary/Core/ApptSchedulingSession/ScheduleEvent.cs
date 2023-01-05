using HospitalLibrary.Core.AppointmentSchedulingSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    public class ScheduleEvent : DomainEvent
    {
        public ScheduleEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
