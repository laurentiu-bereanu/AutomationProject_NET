using AutomationProject_NET.AutomationFramework.Factory.Manager;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Factory
{
    public class DriverFactory
    {
        public static IWebDriver CreateInstance(string browser)
        {
            IWebDriver driver;
            BrowserList browserType = (BrowserList)Enum.Parse(typeof(BrowserList), browser, true);

            driver = browserType switch
            {
                BrowserList.CHROME => new ChromeDriverManager().CreateDriver(),
                BrowserList.FIREFOX => new FirefoxDriverManager().CreateDriver(),
                _ => throw new NotSupportedException($"Browser '{browserType}' is not supported.")
            };

            return driver;
        }
    }
}

