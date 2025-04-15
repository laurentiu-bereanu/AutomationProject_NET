using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Elements
{
    public class TextBoxPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/text-box";

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

        [FindsBy(How = How.XPath, Using = "//p[@id='name']")]
        private readonly IWebElement _outputNameText = null!;

        [FindsBy(How = How.XPath, Using = "//p[@id='email']")]
        private readonly IWebElement _outputEmailText = null!;

        [FindsBy(How = How.XPath, Using = "//p[@id='currentAddress']")]
        private readonly IWebElement _outputCurrentAddressText = null!;

        [FindsBy(How = How.XPath, Using = "//p[@id='permanentAddress']")]
        private readonly IWebElement _outputPermanentAddressText = null!;

        public TextBoxPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
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
            _elementMethods.ClickElement(_submitButton);
        }

        public void PopulateFormWithData(string name, string email, string currentAddress, string permanentAddress)
        {
            _fullNameField.SendKeys(name);
            _emailField.SendKeys(email);
            _currentAddressField.SendKeys(currentAddress);
            _permanentAddressField.SendKeys(permanentAddress);
        }

        public string GetOutputNameText()
        {
            return _outputNameText.Text;
        }

        public string GetOutputEmailText()
        {
            return _outputEmailText.Text;
        }

        public string GetOutputCurrentAddressText()
        {
            return _outputCurrentAddressText.Text;
        }

        public string GetOutputPermanentAddressText()
        {
            return _outputPermanentAddressText.Text;
        }
    }
}
