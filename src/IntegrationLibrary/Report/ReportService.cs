using System;
using System.Collections.Generic;
using Castle.Core.Configuration;
using IntegrationAPI.DTO;

namespace IntegrationLibrary.Report
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
       // private readonly ISendingReportService  _sendingReportService;
      
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
           // _sendingReportService = sendingReportService;
        }

        public IEnumerable<Report> GetAll()
        {
            return _reportRepository.GetAll();
        }
      
        
        public Report GetById(Guid id)
        {
            return _reportRepository.GetById(id);
        }
        

        public void Create(ReportDTO reportDTO)
        {
            Report newReport = ReportDtoAdapter.NewReport(reportDTO);

            foreach (Report report in GetAll())
            {
                if (report.Matches(newReport.Id))
             {
                    report.Period = newReport.Period;
                    Update(reportDTO);
                    return;

                }

               
            }
           
            _reportRepository.Create(newReport);
            }
       


        public void Update(ReportDTO reportDto)
        {
            foreach (Report report in GetAll())
            {
                if (report.Id == reportDto.Id)
             {
                    report.Period = reportDto.Period;
                    report.ConfigurationDate=DateTime.Now;

                }

                _reportRepository.Update(report);
            }

        }
        
    }

    
}