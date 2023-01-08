using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.Storage
{
    public interface IEventStore
    {
        IEnumerable<EventStream> GetAll();

        EventStream GetById(int id);
        void NewEvent(EventStream eventStream);
        EventStream FindLastEvent();
    }
}
