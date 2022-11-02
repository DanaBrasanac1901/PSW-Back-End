using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmailSend _emailSend;
        private string _email;
        public AppointmentsController(IAppointmentService appointmentService, IEmailSend emailSend)
        {
            _appointmentService = appointmentService;
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
        public ActionResult Update(string id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.Id)
            {
                return BadRequest();
            }

            try
            {
                _appointmentService.Update(appointment);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(appointment);
        }

        // DELETE api/appointments/2
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            

            var appointment = _appointmentService.GetById(id);
            if (appointment.PatientId == "PAT1")
            {
                _email = "imeprezime0124@gmail.com";
            }
            else if (appointment.PatientId == "PAT2")
            {
                _email = "milos.adnadjevic@gmail.com";
            }
            else if (appointment.PatientId =="PAT3")
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