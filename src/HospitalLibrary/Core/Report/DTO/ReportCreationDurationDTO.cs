using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportCreationDurationDTO
    {
        private string reportId;
        private TimeSpan durationInSeconds;
        private string durationString;

        public ReportCreationDurationDTO(string v, TimeSpan timeSpan)
        {
            this.reportId = v;
            this.durationInSeconds = timeSpan;
            this.durationString = timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString();
        }
    }
}
