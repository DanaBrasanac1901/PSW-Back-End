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
        public int id { get; set; }
        public string doctorId { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string description { get; set; }

        public ViewAllVacationRequestsDTO() { }
    }
}
