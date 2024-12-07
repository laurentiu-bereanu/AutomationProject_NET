using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject_NET.AutomationFramework
{
    public class BaseTest
    {
        protected IWebDriver Driver = null!;

        [SetUp]
        public void Setup()
        {
            var baseURL = "https://demoqa.com/";

            Driver = new ChromeDriver();
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
