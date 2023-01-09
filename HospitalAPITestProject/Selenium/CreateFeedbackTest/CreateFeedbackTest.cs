using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPITestProject.Selenium.CreateFeedbackTest.Pages;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.User;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Xunit;

namespace HospitalAPITestProject.Selenium.CreateFeedbackTest
{
    public class CreateFeedbackTest: BaseIntegrationTest
    {
        private IWebDriver driver;
        private LandingPage landingPage;
        private HomePage homePage;
        private LoginPage loginPage;

        public CreateFeedbackTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static FeedbackController SetupFController(IServiceScope scope)
        {
            return new FeedbackController(scope.ServiceProvider.GetRequiredService<IFeedbackService>());

        }

        private static CredentialsController SetupCController(IServiceScope scope)
        {
            return new CredentialsController(scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailSendService>());
        }

        [Fact]
        public void CreatesFeedback()
        {
            using var scope = Factory.Services.CreateScope();       
            var fcontroller = SetupFController(scope);
            var ccontroller = SetupCController(scope);
           
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");
            driver = new ChromeDriver(options);

            landingPage = new LandingPage(driver);
            landingPage.Navigate();
            Assert.True(landingPage.GridButtonDisplayed());
            Assert.True(landingPage.SignInButtonDisplayed());
            Thread.Sleep(1000);
            landingPage.ClickGrid();
            Thread.Sleep(1000);
            landingPage.ClickSignIn();
            landingPage.WaitForSignIn();

            loginPage = new LoginPage(driver);
            loginPage.EnsurePageIsDisplayed();
            Assert.True(loginPage.EmailDisplayed());
            Assert.True(loginPage.PasswordDisplayed());
            Assert.True(loginPage.LoginDisplayed());
            Thread.Sleep(1000);
            loginPage.InsertEmail("manager");
            Thread.Sleep(1000);
            loginPage.InsertPassword("manager");
            Thread.Sleep(500);
            loginPage.ClickLogin();
            loginPage.WaitForLogin();

            homePage = new HomePage(driver);
            homePage.EnsurePageIsDisplayed();
            Assert.True(homePage.OpenDialogButtonDisplayed());
            homePage.ClickCreate();
            Assert.True(homePage.CreateTableDisplayed());
            Assert.True(homePage.AnonCheckBoxDisplayed());
            Assert.True(homePage.VisibleCheckBoxDisplayed());
            Assert.True(homePage.TextInputDisplayed());
            Assert.True(homePage.PostButtonDisplayed());

            homePage.ClickAnonymous();
            homePage.ClickVisible();
            homePage.InsertText("ovo je komentar");
            homePage.ClickPost();

            //za proveru neki count redova tabele fidbeka pa uporediti sa count posle
            Dispose();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
