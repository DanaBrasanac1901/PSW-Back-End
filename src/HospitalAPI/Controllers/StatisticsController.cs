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

        // ALWAYS FIRST CALL GRAPH AND TABLE SECOND
        // GraphData also stores table data so if table is called first it will throw exception

        [HttpGet("schedule/graphs")]
        public ActionResult GetGraphData()
        {
            return Ok(_schedulingStatisticsService.GetStatistics());
        }

        [HttpGet("schedule/table")]
        public ActionResult GetTableData()
        {
            return Ok(_schedulingStatisticsService.GetTableStats());
        }
    }
}
