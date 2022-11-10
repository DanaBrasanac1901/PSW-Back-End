using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
  
        public AppointmentsController(IAppointmentService appointmentService, IDoctorService doctorService, IEmailSendService emailSend)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            
        }

        // GET: api/appointments
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        // GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        [HttpPost]
        public ActionResult Create(CreateAppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appointmentService.Create(appointmentDTO);
            Appointment appointment = new Appointment();
            return NoContent();
        }

        // PUT api/appointments/2
        [HttpPut("{id}")]
        public ActionResult Update(RescheduleAppointmentDTO appointmentDTO)
        {
            //Console.WriteLine("MAMA DOBRO SAM!");
            //Appointment appointment = _appointmentService.GetById(appointmentDTO.id);
            //string timeParse = appointmentDTO.date + " " + appointmentDTO.time + ":00";
            //DateTime newStartTime = Convert.ToDateTime(timeParse);
            ////appointment.Start = newStartTime;
            //Boolean flag1 = _appointmentService.CheckIfAppointmentIsSetInFuture(newStartTime);
            //Boolean flag2 = _appointmentService.IsAvailableDateOnly(newStartTime,appointment.DoctorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                _appointmentService.Update(appointmentDTO);
            }catch
            {
                return BadRequest();
            }
            return Ok(appointmentDTO);
        }

        // DELETE api/appointments/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {


            var appointment = _appointmentService.GetById(id);
            

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(id);
            return NoContent();
        }


        [HttpPost]
        [Route("[action]")]
        public ActionResult CreateAppointment(CreateAppointmentDTO appDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string idFlag = _appointmentService.Create(appDTO);
            return CreatedAtAction("GetById", new { id = idFlag }, appDTO);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAllByDoctor(string id)
        {
            var appointments = _appointmentService.GetAllByDoctor(id);
            if (appointments == null)
                return NotFound();

            return Ok(appointments);

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult GetAppToReschedule(string id)
        {
            var appointment = _appointmentService.GetAppoitnemtnToReschedule(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
    }
}
