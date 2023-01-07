using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class ReportCreated : DomainEvent
    {
        public ReportCreated() { }

        public ReportCreated(string aggregateId) : base(aggregateId)
        {
            CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; private set; }
    }
}
