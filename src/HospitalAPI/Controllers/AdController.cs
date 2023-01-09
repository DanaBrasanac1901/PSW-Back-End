
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        static readonly private HttpClient client;
        private string ads;
        
        static AdController()
        {
            client = new HttpClient();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ads = await client.GetStringAsync("https://localhost:44335/api/Advertisements");
            List<string> deserializedAds = JsonConvert.DeserializeObject<List<string>>(ads);
            return Ok(deserializedAds);
        }






    }
}
