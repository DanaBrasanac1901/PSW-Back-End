using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Blood.DTOS;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


namespace HospitalTests.Integration
{
    public class BloodTests : BaseIntegrationTest
    {
        private object request;

        public BloodTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static BloodController SetupController(IServiceScope scope)
        {
            return new BloodController(scope.ServiceProvider.GetRequiredService<IBloodService>());
        }
        private static CreateConsmptionRecordDTO SetUpBloodConsumptionRecordDTO(IServiceScope scope)
        {
            return new CreateConsmptionRecordDTO(scope.ServiceProvider.GetRequiredService<IBloodService>());
        }

        [Fact]
        public void Creates_blood_consumption_record ()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            // promeniti act i assert
            var record = SetUpBloodConsumptionRecordDTO(scope) ;
            var result = ((OkObjectResult)controller.CreateConsumptionRecord(record))?.Value as CreateConsmptionRecordDTO;

            Assert.NotNull(result);
        }
     
        
    }
}
