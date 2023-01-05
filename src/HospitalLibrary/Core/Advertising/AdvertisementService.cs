using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Advertising
{
    public class AdvertisementService:IAdvertisementService
    {
        static readonly private HttpClient client;
        static AdvertisementService() {
            client = new HttpClient();
        }

        public static async Task GetAll() {

            try
            {
                using HttpResponseMessage response = await client.GetAsync("https://localhost:44335/IntegrationAPI/Advertisement");
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
