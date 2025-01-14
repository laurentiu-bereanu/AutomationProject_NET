using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//h5[text()='Elements']")]
        private readonly IWebElement _elementsButton = null!;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Forms']")]
        private readonly IWebElement _formsButton = null!;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Widgets']")]
        private readonly IWebElement _widgetsButton = null!;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnElementsSection()
        {
            _elementsButton.Click();
        }

        public void ClickOnFormsSection()
        {
            _formsButton.Click();
        }

        public void ClickOnWidgetsSection()
        {
            _widgetsButton.Click();
        }
    }
}
