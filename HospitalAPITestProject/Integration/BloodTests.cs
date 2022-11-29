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


        private static BloodConsumptionRecordDTO SetUpBloodConsumptionRecordDTO(IServiceScope scope)
        {
            return new BloodConsumptionRecordDTO(scope.ServiceProvider.GetRequiredService<IBloodService>());
        }


        [Fact]
        public void Creates_blood_consumption_record ()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var record = SetUpBloodConsumptionRecordDTO(scope);
            var result = ((CreatedAtActionResult)controller.CreateConsumptionRecord(record))?.Value as BloodConsumptionRecord;

            Assert.NotNull(result);
        }

    }
}
