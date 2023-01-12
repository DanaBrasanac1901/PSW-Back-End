using AutoMapper;
using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Tender;
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibrary.BloodBank;
using IntegrationLibrary.TenderHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : Controller
    {
        private readonly ITenderHandlerService _tenderHandlerService;
        public TendersController(ITenderHandlerService tenderService)
        {
            _tenderHandlerService = tenderService;
        }


        // GET: api/tenders
        [HttpGet]
        public ActionResult GetAll()
        {
            List<TenderHandler> tenderHandlers = _tenderHandlerService.GetAll().ToList();
            List<Tender> tenders = new List<Tender>();
            foreach (TenderHandler tenderHandler in tenderHandlers)
                tenders.Add(tenderHandler.Tender);
            return Ok(tenders);
        }

        // GET api/tenders/2

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var tender = _tenderHandlerService.GetById(id);
            if (tender == null)
            {
                return NotFound();
            }

            return Ok(tender.Tender);
        }
        // POST api/tenders
        [HttpPost]
        public ActionResult Create(Tender tender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tenderHandlerService.CreateTender(tender);
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
                _tenderHandlerService.UpdateTender(tender);
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
            var tender = _tenderHandlerService.GetById(id);
            if (tender == null)
            {
                return NotFound();
            }

            _tenderHandlerService.DeleteTender(tender.Tender);
            return NoContent();
        }
    }

}
