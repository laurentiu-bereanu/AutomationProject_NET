using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ElementsButton => _driver.FindElement(By.XPath("//h5[text()='Elements']"));

        public void ClickOnElementsSection()
        {
            ElementsButton.Click();
        }
    }
}
