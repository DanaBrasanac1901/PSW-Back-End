using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Doctor.DTOS
{
    public class DoctorAdapter
    {
        public DoctorsShiftDTO DoctorToDoctorsShiftDTO(Doctor doctor)
        {
            DoctorsShiftDTO doctorDTO = new DoctorsShiftDTO();
            doctorDTO.id = doctor.Id;
            doctorDTO.startWorkTime = doctor.StartWorkTime;
            doctorDTO.endWorkTime = doctor.EndWorkTime;
            return doctorDTO;
        }
    }
}
