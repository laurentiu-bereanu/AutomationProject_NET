using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//h5[text()='Elements']")]
        private readonly IWebElement _elementsButton = null!;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnElementsSection()
        {
            _elementsButton.Click();
        }
    }
}
