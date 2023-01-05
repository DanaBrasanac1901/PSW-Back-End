using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.Storage
{
    public class ScheduleAggregateRepository
    {
        private readonly EventStore _eventStore;

        public ScheduleAggregateRepository(EventStore eventStore)
        {
            _eventStore= eventStore;
        }

        
              //Ovo je rehidratacija agregata ja msm 
        public ScheduleAggregate FindById(Guid id)
        {
            var streamName = string.Format("{0}-{1}", typeof(ScheduleAggregate).Name, id.ToString());

            // Check for snapshots

            var fromEventNumber = 0;
            var toEventNumber = int.MaxValue ;

            // pull back all events from snapshot
            var stream = _eventStore.GetStream(streamName, fromEventNumber, toEventNumber);

            var scheduleAggregate = new ScheduleAggregate();

            foreach(var @event in stream)
            {
               scheduleAggregate.Apply(@event);
            }

            return scheduleAggregate;            
        }

        //jedan agregat jedan strim
        public void Add(ScheduleAggregate scheduleAggregate)
        {
            var streamName = string.Format("{0}-{1}", typeof(ScheduleAggregate).Name, scheduleAggregate.Id.ToString());

            _eventStore.CreateNewStream(streamName, scheduleAggregate.Changes);
        }

        //apdejt agregata 
        public void Save(ScheduleAggregate scheduleAggregate)
        {
            var streamName = string.Format("{0}-{1}", typeof(ScheduleAggregate).Name, scheduleAggregate.Id.ToString());

            _eventStore.AppendEventsToStream(streamName, scheduleAggregate.Changes);                      
        }

        /*

                public IEnumerable<ScheduleAggregate> GetAll()
                {
                }

                public ScheduleAggregate GetById(int id)
                {

                }

                public void Create(ScheduleAggregate scheduleAggregate)
                {
                   // _context.Patients.Add(patient);
                    _context.SaveChanges();
                }*/
    }
}
