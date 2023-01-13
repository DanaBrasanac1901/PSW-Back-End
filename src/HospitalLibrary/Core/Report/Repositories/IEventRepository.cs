using HospitalLibrary.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Repositories
{
    public interface IEventRepository
    {
        void Create(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll();

        IEnumerable<string> GetReportIds();

        IEnumerable<TimeSpan> GetDurations();

        IEnumerable<int> GetAllStepsForBack(string reportId);

        IEnumerable<int> GetAllStepsForNext(string reportId);
    }
}
