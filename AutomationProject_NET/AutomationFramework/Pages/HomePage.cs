using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class HomePage
    {
        private readonly ElementMethods _elementMethods;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Elements']")]
        private readonly IWebElement _elementsButton = null!;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Forms']")]
        private readonly IWebElement _formsButton = null!;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Alerts, Frame & Windows']")]
        private readonly IWebElement _alertsFrameWindowsButton = null!;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Widgets']")]
        private readonly IWebElement _widgetsButton = null!;

        [FindsBy(How = How.XPath, Using = "//h5[text()='Interactions']")]
        private readonly IWebElement _interactionsButton = null!;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void ClickOnElement(String name)
        {
            switch (name)
            {
                case "Elements":
                    ClickOnElementsSection();
                    break;
                case "Forms":
                    ClickOnFormsSection();
                    break;
                case "Alerts":
                case "Frame":
                case "Windows":
                case "Alerts, Frame & Windows":
                    ClickOnAlertsFrameWindowsSection();
                    break;
                case "Widgets":
                    ClickOnWidgetsSection();
                    break;
                case "Interactions":
                    ClickOnInteractionsSection();
                    break;
                default:
                    throw new NoSuchElementException(name);
            }
        }

        public void ClickOnElementsSection()
        {
            _elementMethods.ClickElement(_elementsButton);
        }

        public void ClickOnFormsSection()
        {
            _elementMethods.ClickElement(_formsButton); 
        }

        public void ClickOnAlertsFrameWindowsSection()
        {
            _elementMethods.ClickElement(_alertsFrameWindowsButton);
        }

        public void ClickOnWidgetsSection()
        {
            _elementMethods.ClickElement(_widgetsButton);
        }

        public void ClickOnInteractionsSection()
        {
            _elementMethods.ClickElement(_interactionsButton);
        }
    }
}
