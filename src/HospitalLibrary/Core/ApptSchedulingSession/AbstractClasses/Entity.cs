using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
