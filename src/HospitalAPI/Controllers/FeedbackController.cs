using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAll());
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
            return CreatedAtAction("GetById", new {Id=feedback.Id}, feedback);
        }

        [HttpPost("changeApproval/{feedbackId}")]
        public ActionResult ChangeApproval(int feedbackId)
        {
            _feedbackService.ChangeApproval(feedbackId);
            return Ok();
        }


        [HttpPost("changeVisibility/{feedbackId}")]
        public ActionResult ChangeVisibility(int feedbackId)
        {
            _feedbackService.ChangeVisibility(feedbackId);
            return Ok();
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

