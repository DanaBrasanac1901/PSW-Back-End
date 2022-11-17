using System;
using Xunit;

public class LoginTest
{
    var mockPC = new Mock<PatientService>;

    [Test]
    public void ShouldAuthenticateValidUser()
    {
        IMyMockDa mockDa = new MockDataAccess();
        var service = new AuthenticationService(mockDa);

        mockDa.AddUser("Name", "Password");

        Assert.IsTrue(service.DoLogin("Name", "Password"));

        //Ensure data access layer was used
        Assert.IsTrue(mockDa.GetUserFromDBWasCalled);
    }

    [Test]
    public void ShouldNotAuthenticateUserWithInvalidPassword()
    {
        IMyMockDa mockDa = new MockDataAccess();
        var service = new AuthenticationService(mockDa);

        mockDa.AddUser("Name", "Password");

        Assert.IsFalse(service.DoLogin("Name", "BadPassword"));

        //Ensure data access layer was used
        Assert.IsTrue(mockDa.GetUserFromDBWasCalled);
    }
}
