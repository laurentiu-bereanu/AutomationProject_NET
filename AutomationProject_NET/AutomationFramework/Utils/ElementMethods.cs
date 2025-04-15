using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Utils
{
    public class ElementMethods
    {
        private readonly IWebDriver _driver;

        public ElementMethods(IWebDriver driver) 
        {
            _driver = driver;
        }

        public void MoveCursorToElement(IWebElement element)
        {
            Actions actions = new(_driver);
            actions.MoveToElement(element).Perform();
        }

        public void ScrollPageToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver)
                .ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", element);
        }

        public void ClickElement(IWebElement element)
        {
            this.ScrollPageToElement(element);
            element.Click();
        }
    }
}
