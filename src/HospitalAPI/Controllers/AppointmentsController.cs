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
        private readonly IEmailSend _emailSend;
        private string _email;
        public AppointmentsController(IAppointmentService appointmentService, IDoctorService doctorService, IEmailSend emailSend)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _emailSend = emailSend;
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
            Console.WriteLine("MAMA DOBRO SAM!");
            Appointment appointment = _appointmentService.GetById(appointmentDTO.AppointmentId);
            string timeParse = appointmentDTO.Date + " " + appointmentDTO.Time;
            DateTime newStartTime = DateTime.ParseExact(timeParse, "MM-dd-yyyy hh:mm", null);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(_doctorService.IsAvailable(appointment.DoctorId, newStartTime))
            {
                
                _appointmentService.Update(appointmentDTO);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/appointments/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {


            var appointment = _appointmentService.GetById(id);
            if (appointment.PatientId == "Pera Peric")
            {
                _email = "imeprezime0124@gmail.com";
            }
            else if (appointment.PatientId == "Sima Simic")
            {
                _email = "milos.adnadjevic@gmail.com";
            }
            else if (appointment.PatientId == "Djordje Djokic")
            {
                _email = "jales32331@harcity.com";
            }
            //else
            //{
            //    return BadRequest();
            //}

            var message = new Message(new string[] { _email }, "Appointment cancelled", "Dear Sir/Madam, \n Your appointment is cancelled because your doctor has emergency call.\n Please go to our site to make new appointment or call our Call center on 0800/ 100 100. \n Sincerely, \n Your Hospital.");
            _emailSend.SendEmail(message);

            if (appointment == null)
            {
                return NotFound();
            }

            _appointmentService.Delete(appointment);
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
    }
}
