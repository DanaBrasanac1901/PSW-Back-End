using System;
using System.Collections.Generic;
using Castle.Core.Configuration;

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

        public void Create(Report report)
        {
            _reportRepository.Create(report);
        }

        public void Update(Report report)
        {
            _reportRepository.Update(report);
        }

    }

    
}