using HospitalAPI.Controllers;
using HospitalAPI;
using HospitalLibrary.Core.Patient;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
namespace HospitalTests.Integration
{
    public class LoginTest : BaseIntegrationTest
    {
        public LoginTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>());

        }
        [Fact]
        public void Should_Find_User()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Id = -1;
            controller.Create(testPatient);
            var result = controller.GetById(-1);
            controller.Delete(-1);
            Assert.NotNull(result);
        }
        [Fact]
        public void User_Does_Not_Exist()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            controller.Delete(-1);
            var result = controller.GetById(-1);
            Assert.Equal(new NotFoundResult().StatusCode,((result as StatusCodeResult)).StatusCode);
        }
        [Fact]
        public void Username_Does_Not_Exist()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Id = -1;
            testPatient.Email = "non-valid";
            testPatient.Password = "nesto";
            var result = controller.Login(testPatient);
            controller.Delete(-1);
            Assert.Equal(new NotFoundResult().StatusCode, ((result as StatusCodeResult)).StatusCode);
        }
        [Fact]
        public void Wrong_Password()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Email = "valid";
            testPatient.Password = "valid";
            testPatient.Id = -1;
            controller.Create(testPatient);
            testPatient.Password = "non-valid";
            var result = controller.Login(testPatient);
            controller.Delete(-1);
            Assert.Null(result);
        }
        [Fact]
        public void Correct_Information_Login()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Id = -1;
            controller.Create(testPatient);
            testPatient.Email = "valid";
            testPatient.Password = "valid";
            var result = controller.Login(testPatient);
            controller.Delete(-1);
            Assert.NotNull(result);
        }
    }
}
