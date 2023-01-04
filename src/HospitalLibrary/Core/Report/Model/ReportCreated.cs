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
        public ReportCreated(Guid aggregateId) : base(aggregateId)
        {
            
        }
    }
}
