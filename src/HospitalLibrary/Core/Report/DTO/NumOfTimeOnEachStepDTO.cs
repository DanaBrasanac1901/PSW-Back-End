using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class NumOfTimeOnEachStepDTO
    {   public string reportId { get; set; }
        public int step0 { get; set; }
        public int step1 { get; set; }
        public int step2 { get; set; }
        public int step3 { get; set; }
        public int step4 { get; set; }

        public NumOfTimeOnEachStepDTO(string reportId,int step0, int step1, int step2, int step3, int step4)
        {
            this.reportId = reportId;
            this.step0 = step0;
            this.step1 = step1;
            this.step2 = step2;
            this.step3 = step3;
            this.step4 = step4;
        }

        public NumOfTimeOnEachStepDTO()
        {
        }
    }
}
