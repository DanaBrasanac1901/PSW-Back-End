using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Tender;
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibrary.BloodBank;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOffersController : Controller
    {
        private readonly ITenderOfferService _tenderOfferService;
        private readonly IBloodBankService _bloodBankService;
        private readonly IEmailSendService _emailSendService;
        private readonly ITenderService _tenderService;

        public TenderOffersController(ITenderOfferService tenderOfferService, IBloodBankService bloodBankService, IEmailSendService emailSendService, ITenderService tenderService)
        {
            _tenderOfferService = tenderOfferService;
            _bloodBankService = bloodBankService;
            _emailSendService = emailSendService;
            _tenderService = tenderService;
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
        public ActionResult GetByTender()
        {
            int id = Convert.ToInt32(Request.Query["Id"]);
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
        [HttpPost("notify-winner")]
        public ActionResult NotifyWinner(TenderOffer tenderOffer)
        {
            if (ModelState.IsValid)
            {
                var winner= _bloodBankService.GetById(tenderOffer.BloodBankId);
                String email = winner.Email;
                
                Tender tender = _tenderService.GetById(tenderOffer.TenderId);
                var lnkHref = Url.Action("AcceptOffer", "TenderOffers", new { email = email, date = tender.Expiration, id=tender.Id }, "https");
                //HTML Template for Send email
                string subject = "Tender won!";
                string body = "Confirm tender win: \n" + lnkHref;
                //Get and set the AppSettings using configuration manager.

                _emailSendService.SendEmail(new Message(new string[] { email, "docatufe@hotmail.com" }, subject, body));
                return Ok(lnkHref);
            }
            return BadRequest();
        }

        [HttpPost("notify-losers")]
        public ActionResult NotifyLosers(String winem,DateTime expires)
        {
            if (ModelState.IsValid)
            {
                //var winner= _bloodBankService.GetById(tenderOffer.BloodBankId);
                //String email = winner.Email;
                List<BloodBank> banks=_bloodBankService.GetAll().ToList();
                string winneremail = winem;
                List<string> loseremails=new List<string>();
                foreach (BloodBank bank in banks)
                    if(winneremail!= bank.Email)
                    loseremails.Append(bank.Email);
                loseremails.Append("docatufe@hotmail.com");
                string subject = "Tender lost!";
                string body = "Tender expiring" + expires + " has finished, you have not won the tender.";
                //Get and set the AppSettings using configuration manager.
                _emailSendService.SendEmail(new Message(loseremails, subject, body));
            }
            return Ok();
        }
        [HttpGet("accept-offer")]
        public ActionResult AcceptOffer()
        {
            int id = Convert.ToInt32(Request.Query["Id"]);
            DateTime date = DateTime.Parse(Request.Query["Date"]);
            string email = Request.Query["Email"];
            
            _tenderService.Delete(_tenderService.GetById(id));
            NotifyLosers(email,date);
            return Redirect("https//localhost:4200/tenders");
        }
    }

}
