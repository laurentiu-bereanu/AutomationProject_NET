using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class ElementsPage
    {
        [FindsBy(How = How.XPath, Using = "//*[text()='Text Box']")]
        private readonly IWebElement _textBoxButton = null!;

        public ElementsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToTextBox()
        {
            _textBoxButton.Click();
        }
    }
}
