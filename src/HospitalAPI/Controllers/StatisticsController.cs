using HospitalLibrary.Core.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        ISchedulingStatisticsService _schedulingStatisticsService;

        public StatisticsController(ISchedulingStatisticsService schedulingStatisticsService)
        {
            _schedulingStatisticsService = schedulingStatisticsService;   
        }


        [HttpGet("schedule")]
        public ActionResult GetStatistics()
        {
            return Ok(_schedulingStatisticsService.GetStatistics());
        }
    }
}
