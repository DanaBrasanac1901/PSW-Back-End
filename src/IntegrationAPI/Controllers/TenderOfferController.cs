using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Tender;
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.TenderHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderOffersController : Controller
    {
        private readonly ITenderHandlerService _tenderHandlerService;
        private readonly IBloodBankService _bloodBankService;
        private readonly IEmailSendService _emailSendService;

        public TenderOffersController(IBloodBankService bloodBankService, IEmailSendService emailSendService, ITenderHandlerService tenderHandlerService)
        {
            _bloodBankService = bloodBankService;
            _emailSendService = emailSendService;
            _tenderHandlerService = tenderHandlerService;
        }

        // GET: api/tenderOffers
        /*[HttpGet]
        public ActionResult GetAll()
        { 
            return Ok(_tenderHandlerService.GetAll());
        }

        // GET api/tenderOffers/2

        [HttpGet("{id}")]
        public ActionResult GetById(int id, Guid bankID)
        {
            var tenderOffer = _tenderHandlerService.GetById(id,bankID);
            if (tenderOffer == null)
            {
                return NotFound();
            }

            return Ok(tenderOffer);
        }*/
        [HttpGet("Tender/{id}")]
        public ActionResult GetByTender(int id)
        {

            List<TenderHandler> tenderHandlers = _tenderHandlerService.GetAll().ToList();
            List<TenderOffer> tenderoffers = new List<TenderOffer>();
            foreach (TenderHandler tenderHandler in tenderHandlers)
                if (tenderHandler.Tender.Id == id)
                    foreach (TenderOffer offer in tenderHandler.TenderOffers)
                        tenderoffers.Add(offer);
                return Ok(tenderoffers);
        }
        // POST api/tenderOffers
        [HttpPost]
        public ActionResult Create(TenderOffer tenderOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool exists = false;
            TenderHandler tenderHandler = _tenderHandlerService.GetById(tenderOffer.TenderId);
            foreach (TenderOffer offer in tenderHandler.TenderOffers)
                if (tenderOffer.BloodBankId == offer.BloodBankId)
                    exists = true;
            if (!exists)
                _tenderHandlerService.CreateOffer(tenderOffer);
            else
                _tenderHandlerService.UpdateOffer(tenderOffer);
            return Ok();
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
                _tenderHandlerService.UpdateOffer(tenderOffer);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(tenderOffer);
        }

        // DELETE api/tenderOffers/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, Guid bankID)
        {
           /* var tenderOffer = _.GetById(id, bankID);
            if (tenderOffer == null)
            {
                return NotFound();
            }

            _tenderHandlerService.DeleteOffer(tenderOffer);*/
            return Ok();
        }
        [HttpPost("notify-winner")]
        public ActionResult NotifyWinner(TenderOffer tenderOffer)
        {
            if (ModelState.IsValid)
            {
                var winner= _bloodBankService.GetById(tenderOffer.BloodBankId);
                String email = winner.Email;
                
                Tender tender = _tenderHandlerService.GetById(tenderOffer.TenderId).Tender;
                var lnkHref = Url.Action("AcceptOffer", "TenderOffers", new { email = email, date = tender.Expiration, id=tender.Id }, "https");
                //HTML Template for Send email
                string subject = "Tender won!";
                string body = "Confirm tender win: \n" + lnkHref;
                //Get and set the AppSettings using configuration manager.

                _emailSendService.SendEmail(new Message(new string[] { email, "danabrasanac@gmail.com" }, subject, body));
                return Ok(lnkHref);
            }
            return BadRequest();
        }

        [HttpPost("notify-losers")]
        public ActionResult NotifyLosers(string winem, DateTime expires)
        {
            if (ModelState.IsValid)
            {
                //var winner= _bloodBankService.GetById(tenderOffer.BloodBankId);
                //String email = winner.Email;
                List<BloodBank> banks = _bloodBankService.GetAll().ToList();
                string winneremail = winem;
                List<string> loseremails = new List<string>();
                foreach (BloodBank bank in banks)
                    if (winneremail != bank.Email)
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
            TenderHandler tenderHandler = _tenderHandlerService.GetById(id);
            foreach(TenderOffer offer in tenderHandler.TenderOffers)
                _tenderHandlerService.DeleteOffer(offer);
            _tenderHandlerService.DeleteTender(tenderHandler.Tender);
            NotifyLosers(email,date);
            return Redirect("https//localhost:4200/tenders");
        }
    }

}
