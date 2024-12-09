using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationProject_NET.AutomationFramework.Factory.Manager
{
    public class FirefoxDriverManager : IFactory
    {
        public IWebDriver CreateDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

            return new FirefoxDriver();
        }
    }
    
}
