using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public class EventSourcingStatistics : IEventSourcingStatistics
    {
        private readonly IEventRepository _eventRepository;

        public EventSourcingStatistics(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<ReportCreationDurationDTO> GetReportCreationDurations()
        {
            List<TimeSpan> durations = (List<TimeSpan>)_eventRepository.GetDurations();
            List<string> reportIds = (List<string>)_eventRepository.GetReportIds();

            List<ReportCreationDurationDTO> idDurationPairs = new List<ReportCreationDurationDTO>();


            for(int i=0; i<reportIds.Count; i++)
            {
                idDurationPairs.Add(new ReportCreationDurationDTO(reportIds[i], durations[i]));
            }

            return idDurationPairs;
        }
    }
}
