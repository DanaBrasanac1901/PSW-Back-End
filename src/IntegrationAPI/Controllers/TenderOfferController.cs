using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.TenderOffer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOffersController : Controller
    {
        private readonly ITenderOfferService _tenderOfferService;
     

        public TenderOffersController(ITenderOfferService tenderOfferService)
        {
            _tenderOfferService = tenderOfferService;
        }

        // GET: api/tenderOffers
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_tenderOfferService.GetAll());
        }

        // GET api/tenderOffers/2
       
        [HttpGet("{id}")]
        public ActionResult GetById(int id, Guid bankID)
        {
            var tenderOffer = _tenderOfferService.GetById(id,bankID);
            if (tenderOffer == null)
            {
                return NotFound();
            }

            return Ok(tenderOffer);
        }
        [HttpGet("Tender/{id}")]
        public ActionResult GetByTender(int id)
        {
            var tenderOffer = _tenderOfferService.GetByTender(id);
            if (tenderOffer == null)
            {
                return NotFound();
            }

            return Ok(tenderOffer);
        }
        // POST api/tenderOffers
        [HttpPost]
        public ActionResult Create(TenderOffer tenderOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tenderOfferService.Create(tenderOffer);
            return CreatedAtAction("GetById", new { id = tenderOffer.TenderId, bloodBankId=tenderOffer.BloodBankId }, tenderOffer);
        }
        

        // PUT api/tenderOffers/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Guid bankID, TenderOffer tenderOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!id.Equals(tenderOffer.TenderId) && !bankID.Equals(tenderOffer.BloodBankId))
            {
                return BadRequest();
            }

            try
            {
                _tenderOfferService.Update(tenderOffer);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(tenderOffer);
        }

        // DELETE api/tenderOffers/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id,Guid bankID)
        {
            var tenderOffer = _tenderOfferService.GetById(id, bankID);
            if (tenderOffer == null)
            {
                return NotFound();
            }

            _tenderOfferService.Delete(tenderOffer);
            return NoContent();
        }
    }

}
