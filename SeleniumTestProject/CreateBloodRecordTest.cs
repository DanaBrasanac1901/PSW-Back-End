using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class CreateBloodRecordTest
    {
        IWebDriver Driver;

        [SetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            Driver = new ChromeDriver(options);
            Driver.Url = "http://localhost:4200/doctor-home";
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()
        {
            Navigate("http://localhost:4200/bloodRecord/add");

            Click("patient-select");
            ReadOnlyCollection<IWebElement> patientOptions = FindAllById();
            patientOptions[0].Click();
            Sleep(1000);
 

            Click("date-input");
            DeleteCharacters("date-input", 10);
            TypeInInput("date-input", "12/17/2022");
            Sleep(1000);

            Click("time-from");
            TypeInInput("time-from", "10");
            TypeInInput("time-from", "00");
            TypeInInput("time-from", "AM");

            Click("time-to");
            TypeInInput("time-to", "11");
            TypeInInput("time-to", "00");
            TypeInInput("time-to", "AM");

            Click("btn-create");
            Sleep(10000);
            Assert.Pass();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }

        private void Navigate(string url)
        {
            Driver.Url = url;
            Sleep(4000);
        }

        private void Click(string id)
        {
            var element = FindById(id);
            element.Click();
            Sleep(1000);
        }

        private void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        private IWebElement FindById(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        private void TypeInInput(string id, string text, int sleep = 1000)
        {
            var element = FindById(id);
            element.SendKeys(text);
            Sleep(sleep);
        }

        private ReadOnlyCollection<IWebElement> FindAllById(string id)
        {
            return Driver.FindElements(By.Id(id));
        }
    }
}
