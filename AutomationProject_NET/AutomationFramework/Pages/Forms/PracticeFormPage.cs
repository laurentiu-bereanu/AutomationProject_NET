using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Forms
{
    internal class PracticeFormPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/automation-practice-form";

        [FindsBy(How = How.Id, Using = "firstName")]
        private readonly IWebElement _firstNameField = null!;

        [FindsBy(How = How.Id, Using = "lastName")]
        private readonly IWebElement _lastNameField = null!;

        [FindsBy(How = How.XPath, Using = "//*[@for='gender-radio-1']")]
        private readonly IWebElement _maleGenderButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[@for='gender-radio-2']")]
        private readonly IWebElement _femaleGenderButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[@for='gender-radio-3']")]
        private readonly IWebElement _otherGenderButton = null!;

        [FindsBy(How = How.Id, Using = "subjectsInput")]
        private readonly IWebElement _subjectsField = null!;

        public PracticeFormPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void EnterFirstName(string name)
        {
            _firstNameField.SendKeys(name);
        }

        public void EnterLastName(string name)
        {
            _lastNameField.SendKeys(name);
        }

        public void SelectGender(string gender)
        {
            string lowerCaseGender = gender.ToLower();

            switch (lowerCaseGender)
            {
                case "male": { _maleGenderButton.Click(); break; }
                case "female": { _femaleGenderButton.Click(); break; }
                case "other": { _otherGenderButton.Click(); break; }
                default: { Console.WriteLine($"Gender '{gender}' selected not possible"); break; }
            }
        }

        public void EnterSubject(string subject)
        {
            _subjectsField.SendKeys(subject);
            _subjectsField.SendKeys(Keys.Enter);
        }
    }
}
