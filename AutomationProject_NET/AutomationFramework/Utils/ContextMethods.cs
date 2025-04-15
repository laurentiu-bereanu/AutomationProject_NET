using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Utils
{
    public class ContextMethods
    {
        private readonly IWebDriver _driver;

        public ContextMethods(IWebDriver driver) 
        {
            this._driver = driver;
        }

        public void SwitchToFrameContext(IWebElement frame)
        {
            _driver.SwitchTo().Frame(frame);
        }

        public void SwitchToDefaultContext()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public void SwitchToAlertContext()
        {
            _driver.SwitchTo().Alert();
        }
    }
}
