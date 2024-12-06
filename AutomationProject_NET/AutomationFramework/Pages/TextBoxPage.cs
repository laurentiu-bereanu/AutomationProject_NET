using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationProject_NET.AutomationFramework.Pages
{
    public class TextBoxPage
    {
        private readonly IWebDriver _driver;

        public TextBoxPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement FullNameField => _driver.FindElement(By.Id("userName"));

        private IWebElement EmailField => _driver.FindElement(By.Id("userEmail"));

        private IWebElement CurrentAddressField => _driver.FindElement(By.Id("currentAddress"));

        private IWebElement PermanentAddressField => _driver.FindElement(By.Id("permanentAddress"));

        private IWebElement SumbitButton => _driver.FindElement(By.Id("submit"));


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
            SumbitButton.Click();
        }

    }
}
