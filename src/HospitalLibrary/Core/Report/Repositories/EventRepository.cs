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

        public IEnumerable<int> GetAllStepsForNext(string reportId)
        {
            List<int> listOfNexts = new List<int>();

            IEnumerable<NextButtonClicked> nextButtonClicked;

            List<string> reportIds = (List<string>)GetReportIds();

            
            foreach (var id in reportIds)
            {
                if (reportId.Equals(id))
                { 
                       



                         nextButtonClicked = (IEnumerable<NextButtonClicked>)_context.ReportCreationEvents.OfType<NextButtonClicked>().Where(e => e.ReportId == id).ToList();
                         foreach(var next in nextButtonClicked)
                         {
                            if (next.FromStep != null)
                            {
                                listOfNexts.Add(next.FromStep);
                            }
                         }
                    
                  
                }
            }

      


            
        

            return listOfNexts;
        }

        public IEnumerable<int> GetAllStepsForBack(string reportId)
        {
            List<int> listOfBacks = new List<int>();

            List<string> reportIds = (List<string>)GetReportIds();
            
            foreach (var id in reportIds) 
            {
                if (reportId.Equals(id))
                {
               


                
                    IEnumerable<BackButtonClicked> backButtonClicked = (IEnumerable<BackButtonClicked>)_context.ReportCreationEvents.OfType<BackButtonClicked>().Where(e => e.ReportId == id).ToList();
                    foreach (var back in backButtonClicked)
                    {
                        if (back.FromStep != null)
                        {
                            listOfBacks.Add(back.FromStep);
                        }
                    }
                }
            }
        
            return listOfBacks;
        }

    }
}
