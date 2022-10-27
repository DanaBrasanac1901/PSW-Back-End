using HospitalLibrary.Core.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        public IActionResult Index()
        {
            return View();
        }
        public FeedbackController(IFeedbackService _feedbackService)
        {
            this._feedbackService = _feedbackService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAll());
        }
        
        [HttpGet("{patientId}")]
        public ActionResult GetByPatientId(int id)
        {
            var feedback=_feedbackService.GetByPatientId(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new {id=feedback.Id}, feedback);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.Id)
            {
                return BadRequest();
            }

            try
            {
                _feedbackService.Update(feedback);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(feedback);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Delete(feedback);
            return NoContent();
        }
    }
}

