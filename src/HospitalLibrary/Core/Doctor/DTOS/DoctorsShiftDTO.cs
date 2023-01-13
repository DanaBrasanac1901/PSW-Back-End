using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class DoctorsShiftDTO
    {
        public int id { get; set; }
        public int startWorkTime { get; set; }
        public int endWorkTime { get; set; }

        public DoctorsShiftDTO()
        {
        }
    }
}
