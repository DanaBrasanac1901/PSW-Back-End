using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation.DTO
{
    public class CreateVacationRequestDTO
    {
        private IVacationService vacationRequestService;

        public string Start { get; set; }
        public string End { get; set; }
        public string Description { get; set; }
        public bool Urgency { get; set; }

        public CreateVacationRequestDTO() {
            Start = "";
            End = "";
        }

        public CreateVacationRequestDTO(IVacationService vacationRequestService)
        {
            this.vacationRequestService = vacationRequestService;
        }
    }
}
