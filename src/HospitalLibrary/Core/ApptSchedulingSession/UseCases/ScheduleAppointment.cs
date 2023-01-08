using HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses;
using HospitalLibrary.Core.ApptSchedulingSession.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.UseCases
{
    public class ScheduleAppointment :IScheduleAppointment
    {
        
        private IEventStore _eventStore;
        public ScheduleAppointment(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Execute(string eventId, DateTime timeStamp)
        {

            if (eventId == "start") _eventStore.NewEvent(HandleStart(timeStamp));
            else
            {
                var aggregates = GetAggregates();
                EventStream previous = _eventStore.FindLastEvent();
                ScheduleAggregate aggregate = aggregates.Find(f => f.Id == previous.AggregateId);

                if (eventId == "next") _eventStore.NewEvent(HandleNext(aggregate, timeStamp));
                else if (eventId == "back") _eventStore.NewEvent(HandleBack(aggregate, timeStamp));
                else if (eventId == "schedule")
                {
                    _eventStore.NewEvent(HandleSchedule(aggregate, timeStamp)); 
                }
                else if (eventId == "end")
                {
                    _eventStore.NewEvent(HandleEnd(aggregate, timeStamp));
                }
            }
                    
        }

      
        public List<ScheduleAggregate> GetAggregates()
        {
            IEnumerable<EventStream> allEvents = _eventStore.GetAll();
            List<ScheduleAggregate> aggregates = new List<ScheduleAggregate>();
            foreach(EventStream _event in allEvents)
            {
                ScheduleAggregate aggregate =aggregates.FirstOrDefault<ScheduleAggregate>(aggregate=>aggregate.Id == _event.AggregateId);
                if (aggregate != null) aggregate.Changes.Add(_event.ToDomainEvent());
                else
                {
                    ScheduleAggregate newAggregate = new ScheduleAggregate(_event.AggregateId, _eventStore.GetLastVersionOfAggregate(_event.AggregateId));
                    newAggregate.Changes.Add(_event.ToDomainEvent());
                    aggregates.Add(newAggregate);
                    
                }
            }

            return aggregates;
        }


        public EventStream HandleStart(DateTime timeStamp)
        {
           
            ScheduleAggregate aggregate = new ScheduleAggregate(Guid.NewGuid(), 0);
            aggregate.Start(timeStamp);
            return new EventStream(aggregate.Id, aggregate.Version, "start", timeStamp);
        }

        public EventStream HandleNext(ScheduleAggregate aggregate, DateTime timeStamp) {
           
            aggregate.Next(timeStamp);
            return new EventStream(aggregate.Id, aggregate.Version, "next", timeStamp);
       
        }

        public EventStream HandleBack(ScheduleAggregate aggregate, DateTime timeStamp) {

            aggregate.Back(timeStamp);
            return new EventStream(aggregate.Id, aggregate.Version, "back", timeStamp);

        }
        public EventStream HandleSchedule(ScheduleAggregate aggregate, DateTime timeStamp) {

            aggregate.Schedule(timeStamp);
            return new EventStream(aggregate.Id, aggregate.Version, "schedule", timeStamp);
        }

        public EventStream HandleEnd(ScheduleAggregate aggregate, DateTime timeStamp)
        {

            aggregate.End(timeStamp);
            return new EventStream(aggregate.Id, aggregate.Version, "end", timeStamp);
        }
    }
}
