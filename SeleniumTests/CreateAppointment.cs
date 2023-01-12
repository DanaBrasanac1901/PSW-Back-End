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
    class CreateAppointment
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            driver = new ChromeDriver();
            //driver.Url = "http://localhost:4200/appointments/add";
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
            driver.FindElement(By.Name("createAppointmentButton")).Click();
            Thread.Sleep(1000);
            IWebElement patientID = driver.FindElement(By.Id("patientID"));
            SelectElement selectPatientID = new SelectElement(patientID);
            selectPatientID.SelectByIndex(0);
            Thread.Sleep(1000);
            IWebElement day = driver.FindElement(By.Id("startDate"));
            day.SendKeys("01252023");
            Thread.Sleep(1000);
            IWebElement start = driver.FindElement(By.Id("startTime"));
            SelectElement selectStart = new SelectElement(start);
            selectStart.SelectByIndex(1);
            Thread.Sleep(1000);
            IWebElement submit = driver.FindElement(By.Id("submit"));
            submit.Click();
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
