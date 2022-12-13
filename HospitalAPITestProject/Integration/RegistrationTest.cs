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
using HospitalLibrary.Core.User;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Enums;

namespace HospitalTests.Integration
{
    public class RegistrationTest : BaseIntegrationTest
    {
        public RegistrationTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>(),scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailSendService>());

        }
        [Fact]
        public void Should_Register()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            RegisterDTO testPatient=new RegisterDTO { Name = "Ime", Surname = "Prez", Address = "aDRESA", Password = "nekiPassword", Email = "nevidjenpassdosad", Age = 15, Gender = "MALE", Allergies = new string[] {"alergija1", "alergija2"}, Jmbg="0950295705", BloodType="A" };

            var result = controller.Register(testPatient).ToString();

            Assert.Contains("Microsoft.AspNetCore.Mvc.CreatedAtActionResult", result);
        }

        [Fact]
        public void User_Already_Exists()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            RegisterDTO testPatient = new RegisterDTO { Name = "Ime", Surname = "Prez", Address = "aDRESA", Password = "anakefn", Email= "manager", Age = 30, Allergies = new string[] { "alergija3", "alergija4" }, Jmbg="490863946397", BloodType="B" };
            var result = controller.Register(testPatient);
            Assert.Contains("Microsoft.AspNetCore.Mvc.BadRequestObjectResult", result.ToString());
        }



    }
}
