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
/*
        private bool CheckIfAlreadyExists(ReportDTO reportdto)
        {
            bool alreadyExists = false;
            IEnumerable<Report> allReports = GetAll();
            foreach (Report report in allReports)
            {
                if (report.Id == reportdto.Id)
                {
                    alreadyExists = true;
                }
            }

            return alreadyExists;
        }
*/

        public void Update(ReportDTO reportDto)
        {
            Report report = ReportDtoAdapter.NewReport(reportDto);
            _reportRepository.Update(report);
        }
        
    }

    
}