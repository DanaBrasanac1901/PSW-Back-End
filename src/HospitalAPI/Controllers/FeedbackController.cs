using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.Feedback.Injectors;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(HospitalDbContext hospitalDb)
        {
            _feedbackService = new FeedbackServiceInjector().Inject(hospitalDb);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAll());
        }
        
        [HttpGet("patient/{id}")]
        public ActionResult GetByPatientId(int id)
        {
            var feedback=_feedbackService.GetByPatientId(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var feedback = _feedbackService.GetById(id);
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
            return CreatedAtAction("GetById", new {ID=feedback.ID}, feedback);
        }

        [HttpPost("approval-change/{commentID}")]
        public ActionResult ChangeApproval(Feedback feedback)
        {
            _feedbackService.ChangeApproval(feedback);
            return Ok(feedback);
        }
        [HttpPost("changevisibility/{commentID}")]
        public ActionResult ChangeVisibility(Feedback feedback)
        {
            _feedbackService.ChangeVisibility(feedback);
            return Ok(feedback);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.ID)
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

