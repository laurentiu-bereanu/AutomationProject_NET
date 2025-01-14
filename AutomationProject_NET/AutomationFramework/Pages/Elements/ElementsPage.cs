using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Elements
{
    public class ElementsPage : BasePage
    {
        protected override string PageUrl => "/elements";

        [FindsBy(How = How.XPath, Using = "//*[text()='Text Box']")]
        private readonly IWebElement _textBoxButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[text()='Web Tables']")]
        private readonly IWebElement _webTablesButton = null!;

        public ElementsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToTextBox()
        {
            _textBoxButton.Click();
        }

        public void NavigateToWebTables()
        {
            _webTablesButton.Click();
        }

    }
}
