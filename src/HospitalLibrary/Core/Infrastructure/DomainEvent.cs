using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Infrastructure
{
    public abstract class DomainEvent
    {

        public DomainEvent() { }

        public DomainEvent(string aggregateId)
        {
            Id = aggregateId;
        }

        public string Id { get; private set; }
    }
}
