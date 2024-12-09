using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Factory
{
    public interface IFactory
    {
        public IWebDriver CreateDriver();
    }
}
