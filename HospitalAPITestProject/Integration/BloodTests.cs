using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Blood;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalTests.Integration
{
    public class BloodTests : BaseIntegrationTest
    {
        public BloodTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static BloodController SetupController(IServiceScope scope)
        {
            return new BloodController(scope.ServiceProvider.GetRequiredService<IBloodService>());
        }

/*
        [Fact]
        public void Creates_blood_consumption_record ()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            //promeniti act i assert
            //var result = ((OkObjectResult)controller.GetById(1))?.Value as Room;

            //Assert.NotNull(result);
        }*/
    }
}
