
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        static readonly private HttpClient client;
        static AdvertisementController()
        {
            client = new HttpClient();
        }

        /*
        [HttpGet]
        public ActionResult GetAll()
        {
            
           

        }
        */

        public static async Task GetAllAsync()
        {

            try
            {
                using HttpResponseMessage response = await client.GetAsync("http://localhost:5000/IntegrationAPI/Advertisement");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

    }
}
