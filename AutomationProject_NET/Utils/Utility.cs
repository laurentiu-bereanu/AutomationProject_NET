using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationProject_NET.Utils
{
    public static class Utility
    {
        public static void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new(driver);
            actions.MoveToElement(element).Perform();
        }
    }
}
