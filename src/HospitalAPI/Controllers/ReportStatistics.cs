using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Blood.DTOS;
using System;
using HospitalLibrary.Core.Report.Services;
using HospitalLibrary.Core.Report.DTO;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportStatisticsController : ControllerBase
    {
        private readonly IEventSourcingStatistics _statisticsService;

        public ReportStatisticsController(IEventSourcingStatistics statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetReportCreationDurations()
        {

            List<ReportCreationDurationDTO> responseDTOs = _statisticsService.GetReportCreationDurations();
            return Ok(responseDTOs);
        }
    }
}