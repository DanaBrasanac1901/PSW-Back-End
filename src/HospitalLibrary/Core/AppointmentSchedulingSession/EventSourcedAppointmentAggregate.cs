using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.AppointmentSchedulingSession
{
    public abstract class EventSourcedAppointmentAggregate : AppointmentSchedulingSession
    {
        public List<DomainEvent> Changes { get; private set; }
        public EventSourcedAppointmentAggregate()
        {
            Changes = new List<DomainEvent>();
        }

        public abstract void Apply(DomainEvent changes);
    }
}
