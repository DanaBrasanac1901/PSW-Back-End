using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class BackButtonClicked : DomainEvent
    {
        public BackButtonClicked(Guid aggregateId, int numOfSteps) : base(aggregateId)
        {
            NumberOfBackSteps = numOfSteps;
        }

        public int NumberOfBackSteps { get; private set; }
    }
}
