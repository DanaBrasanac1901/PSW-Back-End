using Castle.Core.Internal;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Patient;
using HospitalLibrary.Core.User;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.Core.EmailSender;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;
        private IEmailSendService _emailSendService;

        public PatientsController(IPatientService patientService,IUserService userService, IEmailSendService emailSendService)
        {
            _patientService = patientService;
            _userService = userService;
            _emailSendService = emailSendService;
        }

        // GET: api/patients
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        // GET api/patients/2
       
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
        // POST api/patients
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientService.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDTO regDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Patient patient = new Patient(regDTO);
            _patientService.Register(patient);

            Patient createdPatient = _patientService.GetByEmail(patient.Email);
            if(createdPatient != null)
            {
                User newUser=new User(regDTO,createdPatient.Id);
                _userService.Create(newUser);
            }

           if(!SendActivationEmail(createdPatient.Email)) return BadRequest();
            
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        
        private bool SendActivationEmail(string email)
        {

            var token = _userService.GenerateActivationToken(email);

            if (token != null)
            {
                _userService.SaveTokenToDatabase(email, token);

                var lnkHref = Url.Action("Activate", "Credentials", new { email = email, code = token }, "http");
                string subject = "HealthcareMD Activation Link";
                string body = "Your activation link: " + lnkHref;
                _emailSendService.SendEmail(new Message(new string[] { email, "tibbers707@gmail.com" }, subject, body));
                return true;
            }

            return false;
        }

        

        // PUT api/patients/2
        [HttpPut("{id}")]
        public ActionResult Update(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!id.Equals(patient.Id))
            {
                return BadRequest();
            }

            try
            {
                _patientService.Update(patient);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(patient);
        }

        // DELETE api/patients/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var patient = _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientService.Delete(patient);
            return NoContent();
        }

        [HttpGet("minimal-patients-doctor")]
        public ActionResult GetDoctorsWithLeastPatients() {

            var doctors = _patientService.GetDoctorsWithLeastPatients();
            if(doctors == null)
            {
                return NotFound();
            }

            return Ok(doctors);
        
        
        }

        /*

        [HttpGet("login/{email}")]
        public ActionResult CheckEmail(string email)
        {
            var patient = _patientService.DoesEmailExist(email);
            if(patient==null) return NotFound();

            return Ok(patient);
        }

        [HttpGet("{email}/{password}")]
        public ActionResult GetUser(string email, string password)
        {
            var patient = _patientService.CredentialsValidity(email,password);
            if (patient == null) return NotFound();

            return Ok(patient);
        }

        */
    }

}
