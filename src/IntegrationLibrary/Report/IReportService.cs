using System;
using System.Collections.Generic;
using IntegrationAPI.DTO;

namespace IntegrationLibrary.Report
{
    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        Report GetById(Guid id);
        void Create(ReportDTO report);
        void Update(ReportDTO report);
    }
}