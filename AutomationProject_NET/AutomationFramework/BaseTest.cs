using AutomationProject_NET.AutomationFramework.Factory;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework
{
    public class BaseTest
    {
        protected IWebDriver Driver = null!;

        [SetUp]
        public void Setup()
        {
            var baseURL = "https://demoqa.com/";

            Driver = new DriverFactory().CreateInstance(BrowserList.CHROME.ToString());

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(baseURL);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Dispose();
        }
    }
}
