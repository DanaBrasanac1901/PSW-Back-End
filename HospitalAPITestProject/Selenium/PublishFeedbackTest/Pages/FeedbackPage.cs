﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAPITestProject.Selenium.PublishFeedbackTests.Pages
{
    public class FeedbackPage
    {
        private readonly IWebDriver webDriver;
        public const string URI = "http://localhost:4200/feedback";
        private IWebElement PendingTable => webDriver.FindElement(By.Name("pending-table"));

        private IReadOnlyCollection<IWebElement> PendingRows => webDriver.FindElements(By.XPath("//table[@id='pending-table']/tr"));

        private IWebElement SelectedRow => webDriver.FindElement(By.XPath("//table[@id='pending-table']/tr[0]"));
        private IWebElement ApprovedTable => webDriver.FindElement(By.Name("approved-table"));

        private IReadOnlyCollection<IWebElement> ApprovedRows => webDriver.FindElements(By.XPath("//table[@id='approved-table']/tr"));

        private IWebElement Approve => webDriver.FindElement(By.Name("approve-button"));
     
        public string Title => webDriver.Title;

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return PendingRows.Count > 0;
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

        public bool PendingTableDisplayed()
        {
            return PendingTable.Displayed;
        }

        public bool ApprovedTableDisplayed()
        {
            return ApprovedTable.Displayed;
        }
        public bool ButtonDisplayed()
        {
            return Approve.Displayed;
        }

        public void ClickApprove()
        {
            Approve.Click();
        }

        public void ClickSelected()
        {
            SelectedRow.Click();
        }

        public FeedbackPage(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public int CountApproved()
        {
            return ApprovedRows.Count;

        }

        public int CountPending()
        {
            return PendingRows.Count;

        }

     
    }
}
