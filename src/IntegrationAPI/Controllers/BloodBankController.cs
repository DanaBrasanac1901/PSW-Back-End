using AutoMapper;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;
using IntegrationAPI.BBConnection;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Linq;
using Nest;
using IntegrationAPI.Exceptions.Validation;

namespace IntegrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodBankController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IBloodBankService _IbbService;

       

        public BloodBankController(IBloodBankService IbbService, IMapper mapper) {
            this._IbbService = IbbService;
            this._mapper = mapper;
           
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBloodBanks()
        {
            

            var bloodBanks = _IbbService.GetAll();
           
            return Ok(bloodBanks);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetbyId")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {
            var bloodBank = _IbbService.GetById(id);
            BloodBankRequestValidator.Validate(bloodBank);
            
            return Ok(bloodBank);
        }


        [HttpPost]

        public async Task<IActionResult> AddBloodBank([FromBody] BloodBankDTO bbDTO)
        {
            BloodBank bank1 = new BloodBank();

            bank1 = _mapper.Map<BloodBank>(bbDTO);

            BloodBankRequestValidator.Validate(bank1);
            _IbbService.Create(bank1);
            
           
            return Ok(_mapper.Map<BloodBankDTO>(_IbbService.GetById(bank1.Id)));
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateBloodBank([FromRoute] Guid id, [FromBody] BloodBank bb)
        {
            
            var bloodBank = _IbbService.Update(id, bb);
            BloodBankRequestValidator.Validate(bloodBank);
            return Ok(bloodBank);
        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteBloodBank([FromRoute] Guid id)
        {
            
            _IbbService.Delete(id);
            return Ok(_IbbService.GetAll());
            
        }
        
        [HttpPut] 
        [Route("ConfirmBBAccount/{id:Guid}")]
        public async Task<IActionResult> UpdatePassword([FromRoute] Guid id, [FromBody] object password)
            {
                _IbbService.UpdatePassword(id, password.ToString());
                
                return Ok("Confirmed"); //?
            }

        }

    } 

