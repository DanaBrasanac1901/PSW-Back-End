using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPITestProject.Selenium.PublishFeedbackTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver webDriver;
        public const string URI = "http://localhost:4200";

        private IReadOnlyCollection<IWebElement> Rows => webDriver.FindElements(By.XPath("//table[@id='login-form']/tr"));
        private IWebElement Email => webDriver.FindElement(By.Name("email"));
        private IWebElement Password => webDriver.FindElement(By.Name("password"));

        private IWebElement Login => webDriver.FindElement(By.Name("log-in-button"));

        public string Title => webDriver.Title;

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public bool LoginDisplayed()
        {
            return Login.Displayed;
        }

        public bool EmailDisplayed()
        {
            return Email.Displayed;
        }
        public bool PasswordDisplayed()
        {
            return Password.Displayed;
        }

        public void ClickLogin()
        {
            Login.Click();
        }

        public LoginPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public void InsertEmail(string email)
        {
            Email.SendKeys(email);
           

        }

        public void InsertPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void WaitForLogin()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe(ManagerHomePage.URI));
        }
        

        public void Navigate() => webDriver.Navigate().GoToUrl(URI);
    }
}
