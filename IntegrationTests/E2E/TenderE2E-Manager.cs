using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;


namespace IntegrationTests
{
    public class ManagerTenderTest

    {

        [Fact]
        public void ChromeSession()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:4200/tenders");


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

            var btn = driver.FindElement(By.TagName("button"));

            btn.Click();

            var btn_send = driver.FindElement(By.TagName("button"));

            btn_send.Click();

            Assert.Equal("https://localhost:4200/tenders", driver.Url);

            driver.Quit();
        }
    }
}