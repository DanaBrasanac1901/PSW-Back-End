using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages
{
    public class ReviewReportPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/showreportdev?appointmentId=APP1&patientId=PAT1&reportId=221214023726882754";
       
        private IWebElement Link => driver.FindElement(By.XPath("//input[@id='patient']"));
        private IWebElement Link1 => driver.FindElement(By.XPath("//input[@id='symptom']"));
        private IWebElement Link2 => driver.FindElement(By.XPath("//input[@id='description']"));
        private IWebElement Link3 => driver.FindElement(By.XPath("//input[@id='drug']"));

        public bool LinkDisplayed()
        {
            return Link.Displayed;
        }
        public bool LinkDisplayed1()
        {
            return Link1.Displayed;
        }
        public bool LinkDisplayed2()
        {
            return Link2.Displayed;
        }
        public bool LinkDisplayed3()
        {
            return Link3.Displayed;
        }
   
        public void ClickLink()
        {
            Link.Click();
        }

        public void ClickLink1()
        {
            Link1.Click();
        }
        public void ClickLink2()
        {
            Link2.Click();
        }
        public void ClickLink3()
        {
            Link3.Click();
        }
        public ReviewReportPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);



    }
}
