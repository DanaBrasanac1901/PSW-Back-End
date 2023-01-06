using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.Storage
{
    public class EventStore
    {
        //ovde vljd ide kontekst
        private readonly HospitalDbContext _context;
        public EventStore(HospitalDbContext context)
        {
            _context = context;
        }



        public void CreateNewStream(string streamName, IEnumerable<Object> domainEvents)
        {
            var eventStream = new EventStream(streamName);
            _context.EventStreams.Add(eventStream);
//ovo ispraviti
            AppendEventsToStream(streamName, domainEvents);
        }

        public void AppendEventsToStream(string streamName, IEnumerable<Object> domainEvents)
        {
          //  var stream = _documentSession.Load<EventStream>(streamName);

            foreach (var @event in domainEvents)
            {
            //    _documentSession.Store(stream.RegisterEvent(@event));
            }
        }

        public IEnumerable<Object> GetStream(string streamName, int fromVersion, int toVersion)
        {
            // Get events from a specific version
         //   var eventWrappers = (from stream in _documentSession.Query<EventWrapper>()
                    //              .Customize(x => x.WaitForNonStaleResultsAsOfNow())
                   //              where stream.EventStreamId.Equals(streamName)
                   //              && stream.EventNumber <= toVersion
                   //              && stream.EventNumber >= fromVersion
                    //             orderby stream.EventNumber
                   //              select stream).ToList();

          //  if (eventWrappers.Count() == 0) return null;

            var events = new List<Object>();

           // foreach (var @event in eventWrappers)
           // {
          //      events.Add(@event.Event);
          //  }

            return events;
        }
    }
}
