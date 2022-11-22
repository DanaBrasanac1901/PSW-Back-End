using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Patient;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace HospitalAPITestProject.Integration
{
    public class LoginTests : BaseIntegrationTest
    {
        public LoginTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>());

        }


        [Fact]
        public void Check_if_email_exists()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.CheckEmail("janki@gmail.com")).Value as object;

            

            Assert.NotNull(result);
        }

        [Fact]
        public void Check_login_credentials()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetUser("janki@gmail.com", "nekibzvzpas")).Value as object;



            Assert.NotNull(result);
        }

    }
}
