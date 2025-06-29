using AutomationProject_NET.AutomationFramework.Configuration;
using AutomationProject_NET.AutomationFramework.Factory;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver = null!;

        protected TestSettings Settings = null!;

        protected static readonly ILog log = LogManager.GetLogger(typeof(BaseTest));

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            LogInitializer.Initialize();
        }


        [SetUp]
        public void Setup()
        {
            var serviceProvider = ConfigurationManager.Initialize();
            Settings = serviceProvider.GetRequiredService<TestSettings>();

            var baseURL = Settings.BaseUrl;

            Driver = DriverFactory.CreateInstance(Settings.Browser);

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(baseURL);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(5000);
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
