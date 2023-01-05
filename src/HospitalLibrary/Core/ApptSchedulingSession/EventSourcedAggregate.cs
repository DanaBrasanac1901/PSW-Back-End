﻿using HospitalLibrary.Core.ApptSchedulingSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    public abstract class EventSourcedAggregate : Entity
    {
        public List<DomainEvent> Changes { get; private set; }
        public int Version { get; private set; }
        public EventSourcedAggregate()
        {
            Changes = new List<DomainEvent>();
        }

        public abstract void Apply(DomainEvent changes);
    }
}
