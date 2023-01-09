using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPITestProject.Selenium.CreateFeedbackTest.Pages
{
    public class HomePage
    {
        private readonly IWebDriver webDriver;
        private IWebDriver driver;
        public const string URI = "http://localhost:4200/home";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //proveriti opet sve putanje

        private IWebElement CreateTable => webDriver.FindElement(By.XPath("\\table[@id='create-table']"));

        private IWebElement FeedbackTable => webDriver.FindElement(By.Id("feedback-table"));

        private IWebElement OpenDialogButton => webDriver.FindElement(By.Id("create-feedback-button"));

        private IWebElement AnonCheckBox => webDriver.FindElement(By.Name("anonymous"));

        private IWebElement VisibleCheckBox => webDriver.FindElement(By.Name("visibleToPublic"));
        private IWebElement TextInput => webDriver.FindElement(By.Name("text"));
        private IWebElement PostButton => webDriver.FindElement(By.Name("post-button"));

       

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return FeedbackTable.Displayed;
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

        public bool FeedbackTableDisplayed()
        {
            return FeedbackTable.Displayed;
        }

        public bool CreateTableDisplayed()
        {
            return CreateTable.Displayed;
        }

        public bool OpenDialogButtonDisplayed()
        {
            return OpenDialogButton.Displayed;
        }
        public bool AnonCheckBoxDisplayed()
        {
            return AnonCheckBox.Displayed;
        }
       
        public bool VisibleCheckBoxDisplayed()
        {
            return VisibleCheckBox.Displayed;
        }
        public bool TextInputDisplayed()
        {
            return TextInput.Displayed;
        }

        public bool PostButtonDisplayed()
        {
            return PostButton.Displayed;
        }

        public void ClickCreate()
        {
            OpenDialogButton.Click();
        }

        public void ClickPost()
        {
            PostButton.Click();
        }

        public void ClickAnonymous()
        {
            AnonCheckBox.Click();
        }

        public void ClickVisible()
        {
            VisibleCheckBox.Click();
        }

        

        public void InsertText(string text)
        {
            TextInput.SendKeys(text);


        }

     

    }

}
