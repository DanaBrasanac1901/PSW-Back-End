using IntegrationLibrary.Advertisements;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;
        public AdvertisementsController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ads = _advertisementService.GetAll();
            if(ads == null) return NotFound();
            return Ok(ads);
        }
    }
}
