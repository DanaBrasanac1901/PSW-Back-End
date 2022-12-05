using HospitalLibrary.Core.Consiliums.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public interface IConsiliumService
    {   
        IEnumerable<Consilium> GetAll();
        Consilium Create(CreateConsiliumDoctorsDTO consiliumDto);
        void Update(Consilium consilium);
        List<DateTime> GetPotentialAppointmentTimes(ConsiliumAppointmentInfoDTO consiliumAppointmentInfo);
    }
}
