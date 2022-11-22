using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class GetDoctorsAppointmentsForUrgentVacationDTO
    {
        public string id;
        public string vacationStart;
        public string vacationEnd;

        public GetDoctorsAppointmentsForUrgentVacationDTO()
        {
        }
    }
}
