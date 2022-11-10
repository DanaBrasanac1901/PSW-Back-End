using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Patient;
using HospitalAPITestProject.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalAPITestProject
{
    public class ChosenDoctorTests : BaseIntegrationTest
    {

        public ChosenDoctorTests(TestDataBaseFactory<Startup> factory) : base(factory) { }
       
        private static PatientsController SetupController(IServiceScope scope)
        {
            return new PatientsController(scope.ServiceProvider.GetRequiredService<IPatientService>(), scope.ServiceProvider.GetRequiredService<IDoctorService>());
           
        }
        
        [Fact]
        public void Retrieves_all_doctors()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

         
        }

        [Fact]
        public void Returns_doctor_with_least_patients()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


        }

        [Fact]
        public void Returned_doctors_with_max_two_more_patients()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);


        }





    }
}
