using HospitalLibrary.Core.ApptSchedulingSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Statistics
{
    internal interface ISchedulingStatisticsService
    {
        public List<List<StatisticEntry>> GetStatistics(List<ScheduleAggregate> aggregates);
    }
}
