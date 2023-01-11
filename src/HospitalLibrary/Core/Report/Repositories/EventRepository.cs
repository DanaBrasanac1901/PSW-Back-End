using HospitalLibrary.Core.Infrastructure;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly HospitalDbContext _context;

        public EventRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(DomainEvent domainEvent)
        {
            _context.ReportCreationEvents.Add(domainEvent);
            _context.SaveChanges();

        }

        public IEnumerable<DomainEvent> GetAll()
        {
            return _context.ReportCreationEvents.ToList();
        }

        public IEnumerable<string> GetReportIds()
        {
            return _context.ReportCreationEvents.ToList().GroupBy(e => e.ReportId).Select(e => e.FirstOrDefault().ReportId).ToList();
        }

        public IEnumerable<TimeSpan> GetDurations()
        {

            List<TimeSpan> durations = new List<TimeSpan>();

            List<string> reportIds = (List<string>)GetReportIds();
            foreach(string reportId in reportIds)
            {
                ReportCreated reportCreated = (ReportCreated)_context.ReportCreationEvents.OfType<ReportCreated>().Where(e => e.ReportId == reportId).FirstOrDefault();
                ReportFinished reportFinished = (ReportFinished)_context.ReportCreationEvents.OfType<ReportFinished>().Where(e => e.ReportId == reportId).FirstOrDefault();

                if (reportCreated != null && reportFinished != null)
                    durations.Add(reportFinished.FinishedAt.Subtract(reportCreated.CreatedAt));
            }

            return durations;
        }
    }
}
