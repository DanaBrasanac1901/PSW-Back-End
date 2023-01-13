using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class GetDoctorsAppointmentsForUrgentVacationDTO
    {
        public int id;
        public string vacationStart;
        public string vacationEnd;

        public GetDoctorsAppointmentsForUrgentVacationDTO()
        {
        }

        public GetDoctorsAppointmentsForUrgentVacationDTO(int id, string vacationStart, string vacationEnd)
        {
            this.id = id;
            this.vacationStart = vacationStart;
            this.vacationEnd = vacationEnd;
        }
    }
}
