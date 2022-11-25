using HospitalAPI.Controllers;
using HospitalAPI;
using HospitalLibrary.Core.Patient;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using HospitalLibrary.Core.User;

namespace HospitalTests.Integration
{
    public class LoginTest : BaseIntegrationTest
    {
        public LoginTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

       // private static CredentialsController SetupController(IServiceScope scope)
      //  {
           // return new CredentialsController(scope.ServiceProvider.GetRequiredService<IPatientService>());

      //  }
        
        [Fact]
        public void User_Does_Not_Exist()
        {

            using var scope = Factory.Services.CreateScope();
            // var controller = SetupController(scope);
            User user1 = new User { Id = 20, Name = "nema", Surname = "korisnika", Email = "nekinepostojeci@gmail.com", Password = "nekinepostojecipass", Role = "DOCTOR" };
           //var result = controller.Login(user1);
           // Assert.Null(result);
        }
  
        [Fact]
        public void Correct_Information_Login()
        {
            using var scope = Factory.Services.CreateScope();
            //var controller = SetupController(scope);
            User user = new User { Id = 2, Name = "Milica", Surname = "Todorovic", Email = "mtodorovic@hotmail.com", Password = "pass2", Role = "DOCTOR" };
          //  var result = controller.Login(user);

           // Assert.NotNull(result);
        }
    }
}
