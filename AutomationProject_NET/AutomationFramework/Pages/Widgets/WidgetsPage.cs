using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Widgets
{
    public class WidgetsPage : BasePage
    {
        protected override string PageUrl => "/widgets";

        public WidgetsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
