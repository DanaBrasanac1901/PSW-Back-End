using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Consiliums.DTO;

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


        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateConsilium(CreateConsiliumDTO consiliumDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Consilium consilium = _consiliumService.Create(consiliumDto);
        
            return CreatedAtAction("GetById", new { id = consilium.Id }, consilium);
        }


    }
}