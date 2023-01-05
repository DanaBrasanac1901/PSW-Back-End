using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    class RescheduleAppointment
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            driver = new ChromeDriver();
            driver.Url = "http://localhost:4200/appointments/reschedule";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            Thread.Sleep(1000);
            IWebElement appointmentID = driver.FindElement(By.Name("appId"));
            appointmentID.SendKeys("APP5");
            Thread.Sleep(1000);
            IWebElement date = driver.FindElement(By.Name("date"));
            date.SendKeys("25Jan");
            Thread.Sleep(1000);
            IWebElement time = driver.FindElement(By.Name("time"));
            time.SendKeys("14:30");
            Thread.Sleep(1000);
            IWebElement submit = driver.FindElement(By.Name("submit"));
            submit.Click();

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
