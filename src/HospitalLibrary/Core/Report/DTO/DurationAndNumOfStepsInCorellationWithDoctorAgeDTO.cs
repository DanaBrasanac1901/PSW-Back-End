using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class DurationAndNumOfStepsInCorellationWithDoctorAgeDTO
    {
        string reportId { get; set; }
        int age { get; set; }  

        int numberOfSteps { get; set; }

        int duration { get; set; }

        string durationString { get; set; }

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
