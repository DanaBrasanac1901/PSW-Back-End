using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class CreateBloodRecord
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
            IWebElement bloodRecord = driver.FindElement(By.Name("bloodRecord"));
            bloodRecord.Click();
            Thread.Sleep(1000);
            IWebElement amount = driver.FindElement(By.Id("amount"));
            amount.Clear();
            amount.SendKeys("5");
            Thread.Sleep(1000);
            IWebElement type = driver.FindElement(By.Id("type"));
            SelectElement select = new SelectElement(type);
            select.SelectByText("A");
            Thread.Sleep(1000);
            IWebElement reason = driver.FindElement(By.Id("reason"));
            reason.SendKeys("Operation");
            Thread.Sleep(1000);
            IWebElement button = driver.FindElement(By.Id("button"));
            button.Click();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}