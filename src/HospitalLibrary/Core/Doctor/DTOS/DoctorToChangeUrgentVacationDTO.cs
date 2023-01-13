using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class DoctorToChangeUrgentVacationDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public DoctorToChangeUrgentVacationDTO()
        {
        }
    }
}
