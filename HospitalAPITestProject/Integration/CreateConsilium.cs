using HospitalAPI.Controllers;
using HospitalAPI;
using HospitalLibrary.Core.InpatientTreatmentRecord.DTO;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Consiliums;
using HospitalLibrary.Core.Consiliums.DTO;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HospitalAPITestProject.Integration
{
    public class ConsiliumTests : BaseIntegrationTest
    {
        private object request;

        public ConsiliumTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static ConsiliumController SetupController(IServiceScope scope)
        {
            return new ConsiliumController(scope.ServiceProvider.GetRequiredService<IConsiliumService>());
        }

        private static PotentialAppointmentsDTO SetUpCreateConsiliumDTO(IServiceScope scope)
        {
            return new PotentialAppointmentsDTO(scope.ServiceProvider.GetRequiredService<IConsiliumService>());
        }


        [Fact]
        public void Create_consilium()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var consilium = SetUpCreateConsiliumDTO(scope);
            var result = ((CreatedAtActionResult)controller.Create(consilium))?.Value as Consilium;

            Assert.NotNull(result);
        }

    }
}