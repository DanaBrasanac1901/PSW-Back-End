using System;

namespace HospitalLibrary.Core.Infrastructure
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}