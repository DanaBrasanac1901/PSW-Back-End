using System;
using IntegrationLibrary.Report;

namespace IntegrationAPI.DTO
{
    public class ReportDTO
    {
        
        public Period Period { get; set; }
        public Guid Id { get; set; }

        public ReportDTO()
        {
        }
        public ReportDTO(Period period, Guid bloodbankId)
        {
            Id = bloodbankId;
            Period = period;
        }
    }
}
