using System;
using System.Collections.Generic;
using Castle.Core.Configuration;
using IntegrationAPI.DTO;

namespace IntegrationLibrary.Report
{
    public class ReportService: IReportService
    { 
        private readonly IReportRepository _reportRepository;
      
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public IEnumerable<Report> GetAll()
        {
            return _reportRepository.GetAll();
        }
      
        
        public Report GetById(Guid id)
        {
            return _reportRepository.GetById(id);
        }
        

        public void Create(ReportDTO report)
        {
            Report newReport = ReportDtoAdapter.NewReport(report);
            _reportRepository.Create(newReport);

        }


        public void Update(ReportDTO reportDto)
        {
            foreach (Report report in GetAll())
            {
                if (report.Id == reportDto.Id)
                {
                    report.Period = reportDto.Period;
                }
                
                _reportRepository.Update(report);
            }

        }
        
    }

    
}