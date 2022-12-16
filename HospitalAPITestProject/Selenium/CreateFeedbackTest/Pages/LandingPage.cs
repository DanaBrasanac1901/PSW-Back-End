using HospitalAPITestProject.Selenium.CreateFeedbackTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPITestProject.Selenium.CreateFeedbackTest.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver webDriver;
        public const string URI = "http://localhost:4200";
        private IWebElement GridButton => webDriver.FindElement(By.Id("grid"));
        private IWebElement SignIn => webDriver.FindElement(By.XPath("//div[@id='comp-render2']/ul/li"));

       
        //grid je id grid
        // div[@id="comp-render2"]/ul/li
        public LandingPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public bool GridButtonDisplayed()
        {
            return GridButton.Displayed;
        }

        public bool SignInButtonDisplayed()
        {
            return SignIn.Displayed;
        }


        public void ClickGrid()
        {
            GridButton.Click();
        }

        public void ClickSignIn()
        {
            SignIn.Click();
        }


        public void WaitForSignIn()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(LoginPage.URI));
        }


        public void Navigate() => webDriver.Navigate().GoToUrl(URI);
    }
}
