using AutoMapper;
using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Tender;
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibrary.BloodBank;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nest;
using System;
namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : Controller
    {
        private readonly ITenderService _tenderService;
        public TendersController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }


        // GET: api/tenders
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_tenderService.GetAll());
        }

        // GET api/tenders/2

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var tender = _tenderService.GetById(id);
            if (tender == null)
            {
                return NotFound();
            }

            return Ok(tender);
        }
        // POST api/tenders
        [HttpPost]
        public ActionResult Create(Tender tender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tenderService.Create(tender);
            return CreatedAtAction("GetById", new { id = tender.Id }, tender);
        }


        // PUT api/tenders/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Tender tender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!id.Equals(tender.Id))
            {
                return BadRequest();
            }

            try
            {
                _tenderService.Update(tender);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(tender);
        }

        // DELETE api/tenders/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tender = _tenderService.GetById(id);
            if (tender == null)
            {
                return NotFound();
            }

            _tenderService.Delete(tender);
            return NoContent();
        }
    }

}
