using HospitalLibrary.Core.ApptSchedulingSession.Storage;
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
        
        private EventStore _eventStore;
        public ScheduleAppointment(EventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Execute(string eventId, DateTime timeStamp)
        {
            EventStream eventStream;
            if(eventId == "start")
            { 
                eventStream = new EventStream(new Guid(), 0, eventId, timeStamp);
            }
            else
            { 
                EventStream previous = _eventStore.FindLastEvent();
                eventStream = new EventStream(previous.AggregateId,previous.Version+1, eventId, timeStamp);
            }


            _eventStore.NewEvent(eventStream);
               
            
                // agregat instanca.EventKojiGodDaJe(timestamp) ---->ovo nam je sad suvisno sto ne bi trebalo da bude
               
              
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
                    ScheduleAggregate newAggregate = new ScheduleAggregate(_event.AggregateId);
                    newAggregate.Changes.Add(_event.ToDomainEvent());
                    aggregates.Add(newAggregate);
                    
                }
            }

            return aggregates;
        }
    }
}
