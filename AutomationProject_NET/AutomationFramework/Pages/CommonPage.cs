using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class CommonPage : BasePage
    {
        protected override string PageUrl => "/widgets";

        private ElementMethods _elementMethods;

        private IJavaScriptExecutor js;

        public CommonPage(IWebDriver driver) : base(driver) {
            js = (IJavaScriptExecutor)driver;
            _elementMethods = new ElementMethods(driver);
        }

        private List<IWebElement> Elements => _driver.FindElements(By.XPath("//span[@class='text']")).ToList();

        public void GoToDesiredSubMenu(string submenuText)
        {
            js.ExecuteScript("window.scrollTo(0,1000)");
            _elementMethods.SelectElementFromListByText(Elements, submenuText);
        }
    }
}
