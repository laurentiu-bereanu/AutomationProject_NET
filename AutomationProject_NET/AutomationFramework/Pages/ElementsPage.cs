using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class ElementsPage(IWebDriver driver)
    {
        private IWebElement TextBoxButton => driver.FindElement(By.XPath("//*[text()='Text Box']"));

        public void NavigateToTextBox()
        {
            TextBoxButton.Click();
        }
    }
}
