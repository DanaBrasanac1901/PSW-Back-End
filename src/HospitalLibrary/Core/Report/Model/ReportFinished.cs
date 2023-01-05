using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class ReportFinished : DomainEvent
    {
        public ReportFinished(string aggregateId) : base(aggregateId)
        {
            FinishedAt = DateTime.Now;
        }

        public DateTime FinishedAt { get; private set; }
    }
}
