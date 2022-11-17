using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Patient;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace HospitalTests.Integration
{
    public class RegistrationTest : BaseIntegrationTest
    {
        public RegistrationTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>());

        }
        [Fact]
        public void Should_Register_Unvalidated_User()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient=new Patient();
            testPatient.Id = -1;
            controller.Register(testPatient);
            Patient expected = new Patient();
            expected.Id = -1;
            expected.Active = false;
            var result = controller.GetById(-1);

            Assert.True(result.Equals(expected));
        }
        [Fact]
        public void ShouldValidateUser()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            Patient testPatient = new Patient();
            testPatient.Id = -1;
            controller.Register(testPatient);
            controller.Validate(testPatient);
            Patient expected = new Patient();
            expected.Id = -1;
            expected.Active = true;
            var result = controller.GetById(-1);

            Assert.True(result.Equals(expected));
        }
    }
}
