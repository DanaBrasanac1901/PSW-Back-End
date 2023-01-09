using HospitalLibrary.Core.Infrastructure;
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
        }

        public IEnumerable<DomainEvent> GetAll()
        {
            return _context.ReportCreationEvents.ToList();
        }
    }
}
