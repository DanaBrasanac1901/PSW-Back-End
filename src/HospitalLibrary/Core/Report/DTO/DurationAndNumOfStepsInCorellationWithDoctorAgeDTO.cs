using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class DurationAndNumOfStepsInCorellationWithDoctorAgeDTO
    {
        public string reportId { get; set; }
        public int age { get; set; }

        public int numberOfSteps { get; set; }

        public int duration { get; set; }

        public string durationString { get; set; }

        public DurationAndNumOfStepsInCorellationWithDoctorAgeDTO()
        {
        }

        public DurationAndNumOfStepsInCorellationWithDoctorAgeDTO(string reportId,int age,  int numberOfSteps, TimeSpan duration)
        {

            this.reportId = reportId;
            this.age = age;           
            this.numberOfSteps = numberOfSteps;
            this.duration =(int) duration.TotalSeconds;
            this.durationString = duration.Minutes.ToString() + ":" + duration.Seconds.ToString();
        }
    }
}
