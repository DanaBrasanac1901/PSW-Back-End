using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPITestProject.Selenium.PublishFeedbackTests.Pages;
using HospitalLibrary.Core.EmailSender;
using HospitalLibrary.Core.Feedback;
using HospitalLibrary.Core.User;
using HospitalTests.Setup;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HospitalAPITestProject.Selenium.PublishFeedbackTest
{
    public class PublishFeedbackTest: BaseIntegrationTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ManagerHomePage managerHome;
        private FeedbackPage feedbackPage;
        public PublishFeedbackTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static FeedbackController SetupFController(IServiceScope scope)
        {
            return new FeedbackController(scope.ServiceProvider.GetRequiredService<IFeedbackService>());

        }

        private static CredentialsController SetupCController(IServiceScope scope)
        {
            return new CredentialsController(scope.ServiceProvider.GetRequiredService<IUserService>(), scope.ServiceProvider.GetRequiredService<IEmailSendService>());
        }

        [Fact]
        public void PublishesFeedback()
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

            loginPage = new LoginPage(driver);
            loginPage.Navigate();
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

            managerHome = new ManagerHomePage(driver);
            Thread.Sleep(1000);
            Assert.True(managerHome.ToolbarDisplayed());
            Assert.True(managerHome.ButtonDisplayed());
            managerHome.ClickButton();
            managerHome.WaitForFeedback();

            feedbackPage = new FeedbackPage(driver);
            feedbackPage.EnsurePageIsDisplayed();
            Thread.Sleep(2000);
            Assert.True(feedbackPage.ApprovedTableDisplayed());
            Assert.True(feedbackPage.PendingTableDisplayed());
            Assert.True(feedbackPage.ButtonDisplayed());
            int approved = feedbackPage.CountApproved();
            int pending = feedbackPage.CountPending();

            feedbackPage.ClickSelected();
            Thread.Sleep(2000);
            feedbackPage.ClickApprove();
            Thread.Sleep(2000);
            Assert.True(approved == feedbackPage.CountApproved() - 1);
            Assert.True(pending == feedbackPage.CountPending() + 1);
            Thread.Sleep(2000);
            Dispose();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
