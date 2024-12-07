using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Utils
{
    public static class Utility
    {
        public static void MoveCursorToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new(driver);
            actions.MoveToElement(element).Perform();
        }

        public static void ScrollPageToElement(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", element);
        }

    }
}
