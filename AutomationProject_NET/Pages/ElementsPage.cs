using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationProject_NET.Pages
{
    public class ElementsPage
    {
        private readonly IWebDriver _driver;

        public ElementsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement TextBoxButton => _driver.FindElement(By.XPath("//*[text()='Text Box']"));

        public void NavigateToTextBox()
        {
            TextBoxButton.Click();
        }
    }
}
