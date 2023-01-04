using IntegrationLibrary.Advertisements;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpGet("Integration")]
        public ActionResult GetAll()
        {
            var ads = _advertisementService.GetAll();
            if(ads == null) return NotFound();
            return Ok(ads);
        }
    }
}
