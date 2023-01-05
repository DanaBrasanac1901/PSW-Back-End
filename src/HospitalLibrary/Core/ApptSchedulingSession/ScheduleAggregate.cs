using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    public class ScheduleAggregate : EventSourcedAggregate
    {
        public DateTime Begin;
        public DateTime End;
        public List<DateTime> BackTimestamps;
        public List<DateTime> ScheduleTimestamps;
        public List<DateTime> NextTimestamps;

        public override void Apply(DomainEvent changes)
        {
            throw new NotImplementedException();
        }
    }
}
