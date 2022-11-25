using System;
using IntegrationAPI.DTO;

namespace IntegrationLibrary.Report
{
    public class ReportDtoAdapter
    {
        public static Report NewReport(ReportDTO reportDto)
        {
            var reportTransformed = new Report(reportDto.Id, DateTime.Now, reportDto.Period,DateTime.Now);
            return reportTransformed;
        }
        
        public static ReportDTO NewReportDto(Report report)
        {
            var reportTransformed = new ReportDTO(report.Period, report.Id);
            return reportTransformed;
        }
    }
}