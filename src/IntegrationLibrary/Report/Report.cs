using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Blood;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nest;

namespace IntegrationLibrary.Report
{
    public class Report
    {
        public Guid Id { get; set; }
   
        public DateTime ConfigurationDate { get; set; }
        public DateTime LastReportGeneration { get; set; }
        
        public Period Period { get; set; } 
        
      
        public Report(Guid id,  DateTime configurationDate, Period period, DateTime lastReportGeneration)
        {
            Id = id;
            ConfigurationDate = configurationDate;
            Period = period;
            LastReportGeneration = lastReportGeneration;
        }

        public Report(Period period, Guid id)
        {
            Id = id;
            Period = period;
        }

        public Report()
        {
        }
    }
}