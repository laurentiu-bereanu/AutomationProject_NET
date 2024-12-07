using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationProject_NET.AutomationFramework.Factory.Manager
{
    public class ChromeDriverManager : IFactory
    {
        public IWebDriver CreateDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            return new ChromeDriver();
        }
    }
    
}
