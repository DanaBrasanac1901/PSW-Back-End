using HospitalLibrary.Settings;
using Org.BouncyCastle.Utilities;
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
        }

        public EventStream FindLastEvent()
        {
            List<EventStream> allEvents = (List<EventStream>)GetAll();
            EventStream biggest = allEvents.Aggregate((e1, e2) => e1.Id > e2.Id ? e1 : e2);
            return biggest;
        }
    }
}
