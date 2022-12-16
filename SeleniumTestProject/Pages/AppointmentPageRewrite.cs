using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages
{
    public class AppointmentPageRewrite
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/appointments";
        private IWebElement Menu => driver.FindElement(By.Id("review"));
        private IWebElement Link => driver.FindElement(By.XPath("//button[@id='review']"));

        public string Title => driver.Title;

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Timeout = new TimeSpan(0, 0, 20);


        }
        public bool LinkDisplayed()
        {
            return Link.Displayed;
        }
        public void ClickLink()
        {
            Link.Click();
        }

        public AppointmentPageRewrite(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
