using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Vacation;
using HospitalLibrary.Core.Vacation.DTO;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAPITestProject.Integration
{
    public class UrgentVacationTests : BaseIntegrationTest
    {
        private object request;

        public UrgentVacationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static VacationController SetupController(IServiceScope scope)
        {
            return new VacationController(scope.ServiceProvider.GetRequiredService<IVacationService>());
        }

        private static CreateVacationRequestDTO SetUpCreateVacationRequestDTO(IServiceScope scope)
        {
            return new CreateVacationRequestDTO(scope.ServiceProvider.GetRequiredService<IVacationService>());
        }

        [Fact]
        public void Create_urgent_vacation_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var record = SetUpCreateVacationRequestDTO(scope);
            var result = ((CreatedAtActionResult)controller.CreateUrgentRequest(record))?.Value as VacationRequest;

            Assert.NotNull(result);
        }
    }
}
