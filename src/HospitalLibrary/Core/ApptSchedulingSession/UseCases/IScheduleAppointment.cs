using HospitalLibrary.Core.ApptSchedulingSession.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession.UseCases
{
    public interface IScheduleAppointment
    {
        void Execute(string eventId, DateTime timestamp);
        List<ScheduleAggregate> GetAggregates();
        EventStream HandleStart(DateTime timeStamp);

        EventStream HandleBack(ScheduleAggregate aggregate, DateTime timeStamp);

        EventStream HandleSchedule(ScheduleAggregate aggregate, DateTime timeStamp);

        EventStream HandleEnd(ScheduleAggregate aggregate, DateTime timeStamp);
    }
}
