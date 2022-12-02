using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Vacation.DTO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using System.Net;

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

            var created = GetById(newRequest.Id);

            return CreatedAtAction("GetById", new { id = newRequest.Id }, newRequest);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateUrgentRequest(CreateUrgenVacationDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var req = _vacationService.CreateUrgentVacationRequest(request);
            if (req == "Request created.")
                return Ok("Passed");
            else
            {
                return new CustomError(HttpStatusCode.BadRequest,req);
            }
                //return new CustomError(HttpStatusCode.InternalServerError, req);
                
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

        public class CustomError : IActionResult
        {
            private readonly HttpStatusCode _status;
            private readonly object _errorMessage;

            public CustomError(HttpStatusCode status, object errorMessage)
            {
                _status = status;
                _errorMessage = errorMessage;
            }

            public async Task ExecuteResultAsync(ActionContext context)
            {
                var objectResult = new ObjectResult(new
                {
                    errorMessage = _errorMessage
                })
                {
                    StatusCode = (int)_status,
                };

                context.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = (string)_errorMessage;

                await objectResult.ExecuteResultAsync(context);
            }
        }
    }
}