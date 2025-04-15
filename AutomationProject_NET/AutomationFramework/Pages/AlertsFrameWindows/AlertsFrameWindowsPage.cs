using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.AlertsFrameWindows
{
    public class AlertsFrameWindowsPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/alertsWindows";

        [FindsBy(How = How.XPath, Using = "//*[text()='Browser Windows']")]
        private readonly IWebElement _browserWindowsButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[text()='Frames']")]
        private readonly IWebElement _framesButton = null!;

        public AlertsFrameWindowsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void NavigateToFrames()
        {
            _elementMethods.ClickElement(_framesButton);
        }

    }
}
