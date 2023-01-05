using HospitalLibrary.Core.AppointmentSchedulingSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    public class NextButtonEvent : DomainEvent
    {
        public NextButtonEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
