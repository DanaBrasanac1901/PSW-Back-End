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
    class CreateTreatment
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            driver = new ChromeDriver();
            driver.Url = "http://localhost:4200/doctor-home";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            Thread.Sleep(1000);
            IWebElement patientTreatments = driver.FindElement(By.Name("patientTreatments"));
            patientTreatments.Click();
            Thread.Sleep(1000);
            IWebElement createTreatment = driver.FindElement(By.Id("goToCreate"));
            createTreatment.Click();
            Thread.Sleep(1000);
            IWebElement doctorID = driver.FindElement(By.Id("doctorID"));
            doctorID.SendKeys("DOC1");
            Thread.Sleep(1000);
            IWebElement patientID = driver.FindElement(By.Id("patientID"));
            patientID.SendKeys("PAT2");
            Thread.Sleep(1000);
            IWebElement roomID = driver.FindElement(By.Id("roomID"));
            SelectElement selectRoomID = new SelectElement(roomID);
            selectRoomID.SelectByIndex(1);
            Thread.Sleep(1000);
            IWebElement bedID = driver.FindElement(By.Id("bedID"));
            SelectElement selectBedID = new SelectElement(bedID);
            selectBedID.SelectByIndex(1);
            Thread.Sleep(1000);
            IWebElement reason = driver.FindElement(By.Id("reason"));
            reason.SendKeys("Sick");
            Thread.Sleep(1000);
            IWebElement therapy = driver.FindElement(By.Id("therapy"));
            therapy.SendKeys("Antibiotics");
            Thread.Sleep(1000);
            IWebElement submit = driver.FindElement(By.Id("submit"));
            submit.Click();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
