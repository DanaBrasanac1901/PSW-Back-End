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
        IEnumerable<ShowConsiliumDTO> GetAll();
        Consilium Create(PotentialAppointmentsDTO consiliumDto);
        void Update(Consilium consilium);
        List<PotentialAppointmentsDTO> GetPotentialAppointmentTimesForDoctors(ConsiliumRequestDTO consiliumAppointmentInfo);
        List<PotentialAppointmentsDTO> GetPotentialAppointmentTimesForSpecialties(ConsiliumRequestDTO consiliumAppointmentInfo);
    }
}
