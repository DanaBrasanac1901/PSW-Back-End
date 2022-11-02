using AutoMapper;
using IntegrationAPI.DTO;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodBankController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IntegrationDbContext integrationDbContext;

        
        public BloodBankController(IntegrationDbContext integrationDbContext, IMapper mapper) {
            this.integrationDbContext = integrationDbContext;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBloodBanks()
        {
            var bloodBanks = await integrationDbContext.BloodBankTable.ToListAsync();

            return Ok(bloodBanks);
        }   
            
       
    [HttpGet]
    [Route("{id:Guid}")]
    [ActionName("GetbyId")]
    public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {
        var bloodBank = await integrationDbContext.BloodBankTable.FirstOrDefaultAsync(x=>x.Id==id);
            if(bloodBank!=null)
            {
                return Ok(_mapper.Map<BloodBankDTO>(bloodBank));
            }

        return NotFound("Blood bank not found");
        }

  

    [HttpPost]
  
    public async Task<IActionResult> AddBloodBank([FromBody] BloodBankDTO bbDTO)
    {
            BloodBank bank1 = new BloodBank();
            bank1.Id = Guid.NewGuid();
            bank1 = _mapper.Map<BloodBank>(bbDTO);

            await integrationDbContext.BloodBankTable.AddAsync(bank1);
            await integrationDbContext.SaveChangesAsync();

            return await GetbyId(bank1.Id);
    }

    [HttpPut]
    [Route("{id:Guid}")]
 
        public async Task<IActionResult> UpdateBloodBank([FromRoute] Guid id, [FromBody] BloodBank bb)
        {
            var bloodBank = await integrationDbContext.BloodBankTable.FirstOrDefaultAsync(x => x.Id ==id);
            if (bloodBank != null)
            {
                bloodBank.Username = bb.Username;
                bloodBank.Password = bb.Password;
                bloodBank.Path = bb.Path;
                await integrationDbContext.SaveChangesAsync();
                return Ok(bloodBank);
            }

            return NotFound("Blood bank not found");
        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteBloodBank([FromRoute] Guid id)
        {
            var bloodBank = await integrationDbContext.BloodBankTable.FirstOrDefaultAsync(x => x.Id == id);
            if (bloodBank != null)
            {
                integrationDbContext.Remove(bloodBank);
               
                await integrationDbContext.SaveChangesAsync();
                return Ok(bloodBank);
            }

            return NotFound("Blood bank not found");
        }

        [HttpPut]
        [Route("ConfirmBBAccount/{id}")]

        public async Task<IActionResult> UpdateBloodBankAccount([FromRoute] string id, [FromBody] string pp)
        {
            await integrationDbContext.SaveChangesAsync();

            return Ok(id);

        }

    }

}

