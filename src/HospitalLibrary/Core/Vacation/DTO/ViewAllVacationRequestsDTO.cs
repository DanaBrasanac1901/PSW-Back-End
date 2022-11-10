using HospitalLibrary.Core.Enums;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation.DTO
{
    public class ViewAllVacationRequestsDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public bool Urgency { get; set; }

        public VacationRequestStatus Status { get; set; }

        public ViewAllVacationRequestsDTO() { }
    }
}
