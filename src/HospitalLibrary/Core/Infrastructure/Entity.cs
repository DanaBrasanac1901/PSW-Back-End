using System;

namespace HospitalLibrary.Core.Infrastructure
{
    public abstract class Entity
    {
        public string Id { get; protected set; }
    }
}