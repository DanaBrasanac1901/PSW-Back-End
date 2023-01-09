using Castle.Core.Internal;
using HospitalLibrary.Settings;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.Storage
{
    public class EventStore: IEventStore
    {
        //ovde vljd ide kontekst
        private readonly HospitalDbContext _context;
        public EventStore(HospitalDbContext context)
        {
            _context = context;
        }


        public IEnumerable<EventStream> GetAll()
        {
            return _context.EventStreams.ToList();
        }

        public EventStream GetById(int id)
        {
            return _context.EventStreams.Find(id);
        }

        //apdejt agregata 
        public void NewEvent(EventStream eventStream)
        {
            _context.Add(eventStream);
            _context.SaveChanges();

        }

        public EventStream FindLastEvent()
        {
            List<EventStream> allEvents = (List<EventStream>)GetAll();
            if(!allEvents.IsNullOrEmpty()) return allEvents.Aggregate((e1, e2) => e1.Id > e2.Id ? e1 : e2);
            return null;
        }

        public int GetLastVersionOfAggregate(Guid aggregateId)
        {
            IEnumerable<EventStream> allEvents = GetAll();
            //IEnumerable<EventStream> aggregateEvents = GetAll().Where(e => e.AggregateId == aggregateId);
            List<EventStream> aggregateEvents = new List<EventStream>();
            foreach(EventStream eventStream in allEvents)
            {
                if(eventStream.AggregateId == aggregateId)
                {
                    aggregateEvents.Add(eventStream);
                }
            }
             EventStream biggest = aggregateEvents.Aggregate((e1, e2) => e1.Version > e2.Version ? e1 : e2);
            return biggest.Version;
        }
    }
}
