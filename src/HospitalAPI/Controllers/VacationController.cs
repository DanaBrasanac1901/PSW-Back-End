using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Vacation.DTO;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            _vacationService = vacationService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAllByDoctor(string id)
        {
            return Ok(_vacationService.GetAllByDoctor(id));
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetById(int id)
        {
            var request = _vacationService.GetById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateRequest(CreateVacationRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            VacationRequest newRequest = VacationRequestDTOAdapter.VacationRequestDTOToObject(request);
            newRequest.Id = _vacationService.GenerateId();

            _vacationService.CreateVacationRequest(newRequest);

            return CreatedAtAction("GetById", new { id = newRequest.Id }, newRequest);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateUrgentRequest(CreateUrgenVacationDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var req = _vacationService.CreateUrgentVacationRequest(request);
            return CreatedAtAction("GetById", new { id = req.Id }, req);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public ActionResult DeleteVacationRequest(int id)
        {
            var vacation = _vacationService.GetById(id);
            if (vacation == null)
            {
                return NotFound();
            }

            _vacationService.Cancel(id);
            return NoContent();
        }
    }
}