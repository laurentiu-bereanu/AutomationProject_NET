using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Elements
{
    public class ElementsPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/elements";

        [FindsBy(How = How.XPath, Using = "//*[text()='Text Box']")]
        private readonly IWebElement _textBoxButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[text()='Web Tables']")]
        private readonly IWebElement _webTablesButton = null!;

        public ElementsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void NavigateToTextBox()
        {
            _elementMethods.ClickElement(_textBoxButton);
        }

        public void NavigateToWebTables()
        {
            _elementMethods.ClickElement(_webTablesButton);
        }

    }
}
