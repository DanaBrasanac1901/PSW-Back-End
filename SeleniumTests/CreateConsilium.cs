using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Runtime.ExceptionServices;

namespace SeleniumTests
{
    class CreateConsilium
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
            IWebElement consiliums = driver.FindElement(By.Name("consiliums"));
            consiliums.Click();
            Thread.Sleep(1000);
            IWebElement createNewConsilium = driver.FindElement(By.Id("goToCreate"));
            createNewConsilium.Click();
            Thread.Sleep(1000);
            IWebElement topic = driver.FindElement(By.Id("topic"));
            topic.SendKeys("Tema");
            Thread.Sleep(1000);
            IWebElement start = driver.FindElement(By.Id("start"));
            start.SendKeys("25/01/2023 14:00");
            Thread.Sleep(1000);
            IWebElement end = driver.FindElement(By.Id("end"));
            end.SendKeys("29/01/2023");
            Thread.Sleep(1000);
            IWebElement duration = driver.FindElement(By.Id("duration"));
            duration.SendKeys("30");
            Thread.Sleep(1000);
            IWebElement specialities = driver.FindElement(By.Id("radioSpecialities"));
            specialities.Click();
            Thread.Sleep(1000);
            IList<IWebElement> allSpecialities = driver.FindElements(By.Id("selectedSpec"));
            IWebElement cardiologist = allSpecialities[0];
            IWebElement anestesiologist = allSpecialities[1];
            cardiologist.Click();
            anestesiologist.Click();
            Thread.Sleep(1000);
            IWebElement find = driver.FindElement(By.Id("findAppointments"));
            find.Click();
            Thread.Sleep(1000);
            IList<IWebElement> selectedAppointments = driver.FindElements(By.Id("selectedAppointment"));
            for(int i = 0; i < 2; i++)
            {
                selectedAppointments[i].Click();    
            }
            Thread.Sleep(1000);
            IWebElement create = driver.FindElement(By.Id("create"));
            create.Click();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
