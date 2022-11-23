using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class GetAppointmentsUrgentVacationDTO
    {
        public string id { get; set; }
        public string patient { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public GetAppointmentsUrgentVacationDTO()
        {
        }
    }
}
