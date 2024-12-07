using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class HomePage(IWebDriver driver)
    {
        private IWebElement ElementsButton => driver.FindElement(By.XPath("//h5[text()='Elements']"));

        public void ClickOnElementsSection()
        {
            ElementsButton.Click();
        }
    }
}
