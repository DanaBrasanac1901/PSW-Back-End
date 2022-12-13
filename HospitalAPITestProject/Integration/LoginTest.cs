using HospitalAPI.Controllers;
using HospitalAPI;
using HospitalLibrary.Core.Patient;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using HospitalLibrary.Core.User;
using HospitalLibrary.Core.EmailSender;
using Microsoft.Extensions.Configuration;

namespace HospitalTests.Integration
{
    public class LoginTest : BaseIntegrationTest
    {
        public LoginTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
         
        private static CredentialsController SetupController(IServiceScope scope)
       {
            return new CredentialsController(scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailSendService>());
            
       }
        
        [Fact]
        public void User_Does_Not_Exist()
        {

            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            User user = new User { Id = 66, IdByRole=300, Name = "Nema", Surname = "Oveosobe", Email = "nepsotoji@hotmail.com", Password = "pass2", Role = "DOCTOR" };
            var result = controller.Login(user).ToString();
            Assert.Contains("Microsoft.AspNetCore.Mvc.UnauthorizedResult", result);
        }
  
        [Fact]
        public void Correct_Information_Login()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            User user = new User { Id = 1, IdByRole = 1, Name = "Milica", Surname = "Peric", Email = "manager", Password = "AJMjUEYXE / EtKJlD2NfDblnM15ik0Wo547IgBuUFWyJtWRhj5PSBO / ttok4DT679oA == ", Role = "MANAGER" };
            var result = controller.Login(user);
            Assert.NotNull(result);
        }
    }
}
