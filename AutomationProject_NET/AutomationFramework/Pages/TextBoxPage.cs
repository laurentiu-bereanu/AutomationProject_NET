using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class TextBoxPage(IWebDriver driver)
    {
        private IWebElement FullNameField => driver.FindElement(By.Id("userName"));

        private IWebElement EmailField => driver.FindElement(By.Id("userEmail"));

        private IWebElement CurrentAddressField => driver.FindElement(By.Id("currentAddress"));

        private IWebElement PermanentAddressField => driver.FindElement(By.Id("permanentAddress"));

        private IWebElement SumbitButton => driver.FindElement(By.Id("submit"));


        public void EnterFullName(string name)
        {
            FullNameField.SendKeys(name);
        }

        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void EnterCurrentAddress(string currentAddress)
        {
            CurrentAddressField.SendKeys(currentAddress);
        }

        public void EnterPermanentAddress(string permanentAddress)
        {
            PermanentAddressField.SendKeys(permanentAddress);
        }

        public void ClickOnSubmitButton()
        {
            Utility.ScrollPageToElement(driver, SumbitButton);
            SumbitButton.Click();
        }

    }
}
