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
        public ActionResult Create(PotentialAppointmentsDTO consiliumDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consilium consilium = _consiliumService.Create(consiliumDTO);

            if (consilium != null)
                return Ok(consilium);
            else return StatusCode(500);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult GetPotentialConsiliumTimesDoctors(ConsiliumRequestDTO consiliumDTO)
        {
            List<PotentialAppointmentsDTO> potentialTimes = _consiliumService.GetPotentialAppointmentTimesForDoctors(consiliumDTO);

            return Ok(potentialTimes);
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult GetPotentialConsiliumTimesSpecialties(ConsiliumRequestDTO consiliumDTO)
        {
            List<PotentialAppointmentsDTO> potentialTimes = _consiliumService.GetPotentialAppointmentTimesForSpecialties(consiliumDTO);

            return Ok(potentialTimes);
        }
    }
}