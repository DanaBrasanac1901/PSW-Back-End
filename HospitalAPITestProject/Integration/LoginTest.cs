using HospitalAPI.Controllers;
using HospitalAPI;
using HospitalLibrary.Core.Patient;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

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

            Assert.NotNull(result);
        }
        [Fact]
        public void User_Does_Not_Exist()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            controller.Delete(-1);
            var result = controller.GetById(-1);

            Assert.Null(result);
        }
        [Fact]
        public void Username_Does_Not_Exist()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Email = "non-valid";
            testPatient.Password = "nesto";
            var result = controller.Login(testPatient);

            Assert.Null(result);
        }
        [Fact]
        public void Wrong_Password()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Email = "valid";
            testPatient.Password = "non-valid";
            var result = controller.Login(testPatient);

            Assert.Null(result);
        }
        [Fact]
        public void Correct_Information_Login()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Email = "valid";
            testPatient.Password = "valid";
            var result = controller.Login(testPatient);

            Assert.NotNull(result);
        }
    }
}
