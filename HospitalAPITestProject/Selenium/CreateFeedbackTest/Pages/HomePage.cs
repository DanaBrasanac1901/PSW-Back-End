using OpenQA.Selenium;
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
        private IWebElement Table => webDriver.FindElement(By.Name("feedbackTable"));

        private IWebElement Link => webDriver.FindElement(By.Id("createFeedback"));
        
        //unos u ono za pravljenje fidbeka idk
    }
}
