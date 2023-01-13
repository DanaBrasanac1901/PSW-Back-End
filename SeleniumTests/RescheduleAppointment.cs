using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class RescheduleAppointment
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            driver = new ChromeDriver();
            driver.Url = "http://localhost:4200";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.Name("email")).SendKeys("sabane.zivis@gmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("password")).SendKeys("1234");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("loginButton")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("viewAppointmentsButton")).Click();
            Thread.Sleep(1000);
            IWebElement scheduled = driver.FindElement(By.Name("filterAppointmentStatus"));
            SelectElement scheduledApps = new SelectElement(scheduled);
            scheduledApps.SelectByIndex(1);
            driver.FindElement(By.Name("rescheduleAppointmentButton")).Click();

            IWebElement date = driver.FindElement(By.Name("appointmentDate"));
            date.SendKeys("01252023");
            Thread.Sleep(1000);
            IWebElement time = driver.FindElement(By.Name("appointmentTime"));
            SelectElement timeSet = new SelectElement(time);
            timeSet.SelectByIndex(1);
            Thread.Sleep(1000);
            driver.FindElement(By.Name("submit")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Dismiss();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
