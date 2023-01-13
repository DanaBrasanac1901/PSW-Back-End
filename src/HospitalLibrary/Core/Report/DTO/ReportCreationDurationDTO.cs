using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportCreationDurationDTO
    {
        public string reportId { get; set; }
        public int durationInSeconds { get; set; }
        public string durationString { get; set; }

        public ReportCreationDurationDTO()
        {
        }

        public ReportCreationDurationDTO(string reportId, TimeSpan durationInSeconds)
        {
            this.reportId = reportId;
            this.durationInSeconds = (int)durationInSeconds.TotalSeconds;
            this.durationString = durationInSeconds.Minutes.ToString() + ":" + durationInSeconds.Seconds.ToString();
        }
    }
}
