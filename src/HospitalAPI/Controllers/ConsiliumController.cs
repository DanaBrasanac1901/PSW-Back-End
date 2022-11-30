using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Consiliums.DTO;
using System;
using HospitalLibrary.Core.Consiliums;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsiliumController : ControllerBase
    {
        private readonly IConsiliumService _consiliumService;

        public ConsiliumController(IConsiliumService consiliumService)
        {
            _consiliumService = consiliumService;
        }


    }
}