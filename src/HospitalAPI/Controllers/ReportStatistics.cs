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

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetReportAvgNumOfSteps()
        {

            double avgNumOfSteps = _statisticsService.GetAvgNumOfSteps();
            return Ok(avgNumOfSteps);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetNumOfTimeOnEachStep()
        {

            List<NumOfTimeOnEachStepDTO> numOfTimeOnEachStep = _statisticsService.ListNumOfTimeOnEachStep();
            return Ok(numOfTimeOnEachStep);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetDurationAndNumOfStepsInCorellationWithDoctorAge ()
        {

            List<DurationAndNumOfStepsInCorellationWithDoctorAgeDTO> responseDTOs = _statisticsService.GetDurationAndNumOfStepsInCorellationWithDoctorAge();
            return Ok(responseDTOs);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult GetPercentOfSuccess()
        {
            List<NextBackButtonProportionDTO> responseDTOs = _statisticsService.GetRatioOfSuccess();
            return Ok(responseDTOs);
        }
    }
}