using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class NextButtonClicked : DomainEvent
    {
        public NextButtonClicked(Guid aggregateId, int numOfSteps) : base(aggregateId)
        {
            NumberOfNextSteps = numOfSteps;
        }

        public int NumberOfNextSteps { get; private set; }
    }
}
