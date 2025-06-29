using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationProject_NET.AutomationFramework.Configuration;
using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.AlertsFrameWindows
{
    public class FramesCursPage : BasePage
    {
        protected override string PageUrl => "/frames";

        private readonly ElementMethods _elementMethods;

        private readonly JavaScriptMethods _javascriptMethods;

        private IJavaScriptExecutor _executor;

        private IWebElement frame1 => _driver.FindElement(By.Id("frame1"));

        private IWebElement frame2 => _driver.FindElement(By.Id("frame2"));

        private IWebElement frame1Text => _driver.FindElement(By.Id("sampleHeading"));

        public FramesCursPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
            _javascriptMethods = new JavaScriptMethods(driver);
            _executor = (IJavaScriptExecutor)driver;
        }

        public void GetTextFromBigFrame()
        {
            _driver.SwitchTo().Frame(frame1);

            LoggerHelper.Log.Info(frame1Text.Text);

            _driver.SwitchTo().DefaultContent();
        }

        public void GetTextFromSmallFrame()
        {
            _javascriptMethods.ScrollPageVertically(1000);
            _driver.SwitchTo().Frame(frame2);
            _javascriptMethods.ScrollPageDynamically(1000, 1000);
        }

    }
}
