using HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.Events
{
    public class ScheduleButtonPressed : DomainEvent
    {
        public ScheduleButtonPressed(Guid aggregateId, DateTime timeStamp) : base(aggregateId)
        {
            TimeStamp = timeStamp;
        }

        public DateTime TimeStamp { get; private set; }
    }
}
