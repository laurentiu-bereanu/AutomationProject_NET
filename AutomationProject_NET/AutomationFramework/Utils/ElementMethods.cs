using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutomationProject_NET.AutomationFramework.Configuration;
using static System.Net.Mime.MediaTypeNames;

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
            LoggerHelper.Log.Info($"Clicking on element: {element.Text}");
            element.Click();
        }

        public void SelectByText(IWebElement element, string text)
        {
            SelectElement dropdown = new SelectElement(element);
            LoggerHelper.Log.Info($"Select element based on text: {text}");
            dropdown.SelectByText(text);
        }

        public void SelectByValue(IWebElement element, string value)
        {
            SelectElement dropdown = new SelectElement(element);
            LoggerHelper.Log.Info($"Select element based on value: {value}");
            dropdown.SelectByValue(value);
        }

        public void SelectElementFromListByText(IList<IWebElement> webElementList, string text)
        {
            foreach (IWebElement webElement in webElementList)
            {
                if (webElement.Text.Equals(text))
                {
                    ClickElement(webElement);
                    break;
                }
            }
        }

        public DateTime FormatDate(int daysDifference)
        {
            var currentDate = DateTime.Now;
            LoggerHelper.Log.Info($"Current date is: {currentDate}");
            LoggerHelper.Log.Info($"Days difference is: {daysDifference}");
            var formmattedDate = currentDate.AddDays(daysDifference);
            LoggerHelper.Log.Info($"Formatted date is: {formmattedDate}");

            return formmattedDate;
        }
    }
}
