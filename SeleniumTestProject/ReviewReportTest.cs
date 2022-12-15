using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;


namespace SeleniumTestProject
{

    public class ReviewReportTests : IDisposable
    {
        private readonly IWebDriver driver;
        private Pages.HomePage homePage;

        public ReviewReportTests()
        {
            // options for launching Google Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            driver = new ChromeDriver(options);

            
            homePage = new Pages.HomePage(driver);      // create ProductsPage
            homePage.Navigate();                            // navigate to url
            homePage.EnsurePageIsDisplayed();               // wait for table to populate
    


        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}