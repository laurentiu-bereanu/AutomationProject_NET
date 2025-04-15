using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Interactions
{
    public class InteractionsPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/interaction";

        [FindsBy(How = How.XPath, Using = "//*[text()='Selectable']")]
        private readonly IWebElement _selectableButton = null!;

        public InteractionsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void NavigateToSelectable()
        {
            _elementMethods.ClickElement(_selectableButton);
        }
    }
}
