using HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses;
using HospitalLibrary.Core.ApptSchedulingSession.Events;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.Storage
{
    public class EventStream
    {
        public int Id { get; private set; } 
        public Guid AggregateId { get; private set; }
        public int Version { get; private set; }

        public string EventInstance { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public EventStream() { }

        public EventStream(Guid aggregateId, int version, string eventInstance, DateTime timeStamp)
        {
           AggregateId = aggregateId;
            Version= version;
            EventInstance= eventInstance;
            TimeStamp = timeStamp;
        }

        public DomainEvent ToDomainEvent()
        {
            switch (EventInstance)
            {
                case "next":
                        return new NextButtonPressed(AggregateId,TimeStamp);

                case "start": 
                        return new SchedulingStarted(AggregateId,TimeStamp);
                case "end":
                        return new SchedulingEnded(AggregateId,TimeStamp);
                case "back":
                        return new BackButtonPressed(AggregateId,TimeStamp);
                case "schedule":
                        return new ScheduleButtonPressed(AggregateId,TimeStamp);
                default: return null;
            }
        }
    }
}
