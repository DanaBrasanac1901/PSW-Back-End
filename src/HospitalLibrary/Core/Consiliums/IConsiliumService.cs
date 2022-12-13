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
        Consilium Create(CreateConsiliumDTO consiliumDto);
        void Update(Consilium consilium);
        List<string> GetPotentialAppointmentTimesForDoctors(CreateConsiliumDTO consiliumAppointmentInfo);
        List<string> GetPotentialAppointmentTimesForSpecialties(CreateConsiliumDTO consiliumAppointmentInfo);
        List<ConsiliumAppointment> CreateConsiliumAppointments(Consilium consilium);
    }
}
