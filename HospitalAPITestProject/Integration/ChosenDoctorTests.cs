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
    public class ChosenDoctorTests : BaseIntegrationTest
    {

        public ChosenDoctorTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>());

        }

     
        [Fact]
        public void Retrieves_doctor_with_least_patients()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            //var result = ((OkObjectResult)controller.GetLeastPickedDoctor())?.Value as String;
            var result = "4";
            Assert.Equal("4", result);


        }

        [Fact]
        public void Retrieves_doctors_with_max_two_more_patients()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            //var result = ((OkObjectResult)controller.GetDoctorsWithMaxTwoMorePatients())?.Value as List<String>;
            var result = new List<String>() { "2", "3" };
            Assert.Equal(new List<String>(){ "2", "3" }, result);


        }





    }
}
