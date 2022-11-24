using System;
using IntegrationAPI.DTO;

namespace IntegrationLibrary.Report
{
    public class ReportDtoAdapter
    {
        public static Report NewReport(ReportDTO reportDto)
        {
            Report reportTransformed = new Report(reportDto.Id, DateTime.Now, reportDto.Period,DateTime.Now);
            return reportTransformed;
        }
    }
}