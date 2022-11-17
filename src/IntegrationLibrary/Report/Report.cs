using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Blood;
using Nest;

namespace IntegrationLibrary.Report
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid BloodbankId { get; set; }
        public DateTime ConfigurationDate { get; set; }
        public DateTime LastReportGeneration { get; set; }
        
        public Period Period { get; set; } 
        
      
        public Report(Guid id, Guid bloodbankId, DateTime configurationDate, Period period, DateTime lastReportGeneration)
        {
            Id = id;
            BloodbankId = bloodbankId;
            ConfigurationDate = configurationDate;
            Period = period;
            LastReportGeneration = lastReportGeneration;
        }
        
    }
}