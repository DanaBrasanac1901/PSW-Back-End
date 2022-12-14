using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Consiliums.DTO;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsiliumController : ControllerBase
    {
        private readonly IConsiliumService _consiliumService;

        public ConsiliumController(IConsiliumService consiliumService)
        {
            _consiliumService = consiliumService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<ShowConsiliumDTO> consiliumDTOs = (List<ShowConsiliumDTO>)_consiliumService.GetAll();

            return Ok(consiliumDTOs);
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateConsiliumWithDoctors(PotentialAppointmentsDTO consiliumDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consilium consilium = _consiliumService.Create(consiliumDTO);
        
            return CreatedAtAction("GetById", new { id = consilium.Id }, consilium);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult GetPotentialConsiliumTimesDoctors(CreateConsiliumDTO consiliumDTO)
        {
            List<PotentialAppointmentsDTO> potentialTimes = _consiliumService.GetPotentialAppointmentTimesForDoctors(consiliumDTO);

            return Ok(potentialTimes);
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult GetPotentialConsiliumTimesSpecialties(CreateConsiliumDTO consiliumDTO)
        {
            List<PotentialAppointmentsDTO> potentialTimes = _consiliumService.GetPotentialAppointmentTimesForSpecialties(consiliumDTO);

            return Ok(potentialTimes);
        }
    }
}