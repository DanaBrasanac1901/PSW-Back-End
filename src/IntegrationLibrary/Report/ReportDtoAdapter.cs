using System;
using IntegrationAPI.DTO;

namespace IntegrationLibrary.Report
{
    public class ReportDtoAdapter
    {
        public static Report NewReport(ReportDTO reportDto)
        {
            
            Report reportTransformed = new Report(reportDto.Period, reportDto.Id);
            reportTransformed.ConfigurationDate = DateTime.Now;
            reportTransformed.LastReportGeneration = DateTime.Now;
            
            return reportTransformed;
        }
    }
}