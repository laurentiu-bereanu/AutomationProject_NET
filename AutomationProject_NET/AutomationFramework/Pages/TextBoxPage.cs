using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class TextBoxPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "userName")]
        private readonly IWebElement _fullNameField = null!;

        [FindsBy(How = How.Id, Using = "userEmail")]
        private readonly IWebElement _emailField = null!;

        [FindsBy(How = How.Id, Using = "currentAddress")]
        private readonly IWebElement _currentAddressField = null!;

        [FindsBy(How = How.Id, Using = "permanentAddress")]
        private readonly IWebElement _permanentAddressField = null!;

        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement _submitButton = null!;

        public TextBoxPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterFullName(string name)
        {
            _fullNameField.SendKeys(name);
        }

        public void EnterEmail(string email)
        {
            _emailField.SendKeys(email);
        }

        public void EnterCurrentAddress(string currentAddress)
        {
            _currentAddressField.SendKeys(currentAddress);
        }

        public void EnterPermanentAddress(string permanentAddress)
        {
            _permanentAddressField.SendKeys(permanentAddress);
        }

        public void ClickOnSubmitButton()
        {
            Utility.ScrollPageToElement(_driver, _submitButton);
            _submitButton.Click();
        }
    }
}
