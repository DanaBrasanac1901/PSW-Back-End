using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class NextBackButtonProportionDTO
    {  
        public string reportId { get; set; }
        public int pressNext { get; set; }
        public int pressBack { get; set; }

        public double percentOfSuccess { get; set; }

        public NextBackButtonProportionDTO()
        {
        }

        public NextBackButtonProportionDTO(string reportId, int pressNext, int pressBack, double percentOfSuccess)
        {
            this.reportId = reportId;
            this.pressNext = pressNext;
            this.pressBack = pressBack;
            this.percentOfSuccess = percentOfSuccess;
        }
    }
}
