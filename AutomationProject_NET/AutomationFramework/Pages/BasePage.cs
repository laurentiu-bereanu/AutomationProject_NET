using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected readonly IWebDriver _driver = driver;

        protected abstract string PageUrl { get; }

        public bool IsAt()
        {
            return _driver.Url.Contains(PageUrl);
        }
    }
}
