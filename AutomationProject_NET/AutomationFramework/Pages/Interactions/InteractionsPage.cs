using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Interactions
{
    public class InteractionsPage : BasePage
    {
        protected override string PageUrl => "/interaction";

        [FindsBy(How = How.XPath, Using = "//*[text()='Selectable']")]
        private readonly IWebElement _selectableButton = null!;

        public InteractionsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToSelectable()
        {
            _selectableButton.Click();
        }
    }
}
