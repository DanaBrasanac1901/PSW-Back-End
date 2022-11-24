using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation.DTO
{
    public class CreateUrgenVacationDTO
    {
        private IVacationService vacationService;

        public string start { get; set; }
        public string end { get; set; }
        public string description { get; set; }
        public string urgency { get; set; }

        public CreateUrgenVacationDTO() { }

        public CreateUrgenVacationDTO(IVacationService vacationService)
        {
            this.vacationService = vacationService;
            var prika = DateTime.Now.ToString("yyMMddhhmmss");
            //int flag = Int16.Parse(DateTime.Now.ToString("yyMMddhhmmss"));
            this.start = DateTime.Now.AddMinutes(Int64.Parse(DateTime.Now.ToString("yyMMddhhmm"))).ToString();
            this.end = DateTime.Now.AddMinutes(Int64.Parse(DateTime.Now.ToString("yyMMddhhmm"))).AddSeconds(1).ToString();
            this.description = "Stojane";
            this.urgency = "true";
        }
    }
}
