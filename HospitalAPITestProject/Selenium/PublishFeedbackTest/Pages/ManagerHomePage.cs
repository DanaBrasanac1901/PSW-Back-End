using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPITestProject.Selenium.PublishFeedbackTests.Pages
{
    public class ManagerHomePage
    {
     
        private readonly IWebDriver webDriver;
        public const string URI = "http://localhost:4200/manager-home";

        private IWebElement Toolbar => webDriver.FindElement(By.Name("toolbarElement"));
      
        private IWebElement Feedback => webDriver.FindElement(By.Name("feedback-button"));

        public string Title => webDriver.Title;

        public bool ToolbarDisplayed()
        {
            return Toolbar.Displayed;
        }

        public bool ButtonDisplayed()
        {
            return Feedback.Displayed;
        }
        

        public void ClickButton()
        {
            Feedback.Click();
        }

        public ManagerHomePage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        

        public void WaitForFeedback()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(FeedbackPage.URI));
        }
       
    }
}
