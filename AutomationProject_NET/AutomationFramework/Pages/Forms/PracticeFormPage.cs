using AutomationProject_NET.AutomationFramework.Access;
using AutomationProject_NET.AutomationFramework.Configuration;
using AutomationProject_NET.AutomationFramework.Utils;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        [FindsBy(How = How.Id, Using = "userEmail")]
        private readonly IWebElement _userEmailField = null!;

        [FindsBy(How = How.Id, Using = "userNumber")]
        private readonly IWebElement _userNumberField = null!;

        [FindsBy(How = How.XPath, Using = "//*[@for='gender-radio-1']")]
        private readonly IWebElement _maleGenderButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[@for='gender-radio-2']")]
        private readonly IWebElement _femaleGenderButton = null!;

        [FindsBy(How = How.XPath, Using = "//*[@for='gender-radio-3']")]
        private readonly IWebElement _otherGenderButton = null!;

        [FindsBy(How = How.Id, Using = "dateOfBirthInput")]
        private readonly IWebElement _dateOfBirthField = null!;

        [FindsBy(How = How.ClassName, Using = "react-datepicker__month-select")]
        private readonly IWebElement _dateOfBirthMonthSelectField = null!;

        [FindsBy(How = How.ClassName, Using = "react-datepicker__year-select")]
        private readonly IWebElement _dateOfBirthYearSelectField = null!;

        [FindsBy(How = How.Id, Using = "subjectsInput")]
        private readonly IWebElement _subjectsField = null!;

        [FindsBy(How = How.Id, Using = "currentAddress")]
        private readonly IWebElement _currentAddressField = null!;

        [FindsBy(How = How.Id, Using = "state")]
        private readonly IWebElement _stateSelectField = null!;

        [FindsBy(How = How.Id, Using = "city")]
        private readonly IWebElement _citySelectField = null!;

        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement _submitButton = null!;

        public PracticeFormPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void EnterFirstName(string firstName)
        {
            _firstNameField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _lastNameField.SendKeys(lastName);
        }

        public void EnterUserEmail(string email)
        {
            _userEmailField.SendKeys(email);
        }

        public void SelectGender(string gender)
        {
            string lowerCaseGender = gender.ToLower();

            switch (lowerCaseGender)
            {
                case "male": { _maleGenderButton.Click(); break; }
                case "female": { _femaleGenderButton.Click(); break; }
                case "other": { _otherGenderButton.Click(); break; }
                default: { LoggerHelper.Log.Info($"Gender '{gender}' selected not possible"); break; }
            }
        }

        public void EnterUserNumber(string number)
        {
            _userNumberField.SendKeys(number);
        }

        public void CompleteDateOfBirth(int daysDifference)
        {
            var dateTime = _elementMethods.FormatDate(daysDifference);

            _elementMethods.ClickElement(_dateOfBirthField);

            _elementMethods.SelectByText(_dateOfBirthMonthSelectField, dateTime.ToString("MMMM"));
            _elementMethods.SelectByText(_dateOfBirthYearSelectField, dateTime.Year.ToString());
            var correctDay = _driver.FindElement(By.XPath(
               "//*[contains(@class, 'react-datepicker__day') " +
               $"and contains(@class, 'react-datepicker__day--0{dateTime.Day:D2}') " +
               "and not(contains(@class, '--outside-month'))]"));

            _elementMethods.ClickElement(correctDay);
        }

        public void EnterSubject(string subject)
        {
            _subjectsField.SendKeys(subject);
            _subjectsField.SendKeys(Keys.Enter);
        }

        public void EnterSubjects(string[] subject)
        {
            foreach (string subjectItem in subject)
            {
                this.EnterSubject(subjectItem);
            }
        }

        public void CheckHobbies(string[] hobbies)
        {
            int checkBoxNumber = 0;

            foreach (string hobby in hobbies)
            {

                switch (hobby)
                {
                    case "Sports":
                        checkBoxNumber = 1;
                        break;
                    case "Reading":
                        checkBoxNumber = 2;
                        break;
                    case "Music":
                        checkBoxNumber = 3;
                        break;
                }

                var hobbyCheckbox = _driver.FindElement(By.XPath($"//label[@for='hobbies-checkbox-{checkBoxNumber}']"));

                _elementMethods.ClickElement(hobbyCheckbox);

            }
        }

        public void EnterCurrentAddress(string address)
        {
            _currentAddressField.SendKeys(address);
        }

        public void SelectState(string state)
        {
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(5));

            _elementMethods.ClickElement(_stateSelectField);

            var stateOption = wait.Until(driver => driver.FindElement(By.XPath($"//div[contains(@id,'react-select-3-option') and text()='{state}']")));
            stateOption.Click();
        }

        public void SelectCity(string city)
        {
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(5));

            _elementMethods.ClickElement(_citySelectField);

            var cityOption = wait.Until(driver => driver.FindElement(By.XPath($"//div[contains(@id,'react-select-4-option') and text()='{city}']")));
            cityOption.Click();
        }

        public void PopulateStudentRegistrationForm(PracticeFormData practiceFormData)
        {
            this.EnterFirstName(practiceFormData.FirstName);
            this.EnterLastName(practiceFormData.LastName);
            this.EnterUserEmail(practiceFormData.UserEmail);
            this.SelectGender(practiceFormData.Gender);
            this.EnterUserNumber(practiceFormData.Mobile);
            this.CompleteDateOfBirth(practiceFormData.DateOfBirthDaysDifference);
            this.EnterSubjects(practiceFormData.Subjects);
            this.CheckHobbies(practiceFormData.Hobbies);
            this.EnterCurrentAddress(practiceFormData.CurrentAddress);
            this.SelectState(practiceFormData.State);
            this.SelectCity(practiceFormData.City);
        }

        public void SubmitForm()
        {
            _elementMethods.ClickElement(_submitButton);
        }

    }
}
