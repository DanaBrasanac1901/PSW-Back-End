using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.EmailSender;
using HospitalTests.Setup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;


namespace HospitalTests.Integration
{
    public class AppointmentTests : BaseIntegrationTest
    {
        private object request;

        public AppointmentTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static AppointmentsController SetupController(IServiceScope scope)
        {
            //return new AppointmentsController(scope.ServiceProvider.GetRequiredService<IAppointmentService>(), scope.ServiceProvider.GetRequiredService<IDoctorService>());
            return null;
        }


        private static CreateAppointmentDTO SetUpCreateAppointmentDTO(IServiceScope scope)
        {
            return new CreateAppointmentDTO(scope.ServiceProvider.GetRequiredService<IAppointmentService>());
        }


        [Fact]
        public void Creates_appointment()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var record = SetUpCreateAppointmentDTO(scope);
            var result = ((OkObjectResult)controller.CreateAppointment(record))?.Value as string;

            Assert.NotNull(result);
        }

    }
}
