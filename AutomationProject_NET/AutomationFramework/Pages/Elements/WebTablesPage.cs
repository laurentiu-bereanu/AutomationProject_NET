using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Elements
{
    public class WebTablesPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/webtables";

        [FindsBy(How = How.Id, Using = "addNewRecordButton")]
        private readonly IWebElement _addButton = null!;

        [FindsBy(How = How.Id, Using = "firstName")]
        private readonly IWebElement _popupFirstNameField = null!;

        [FindsBy(How = How.Id, Using = "lastName")]
        private readonly IWebElement _popupLastNameField = null!;

        [FindsBy(How = How.Id, Using = "userEmail")]
        private readonly IWebElement _popupEmailField = null!;

        [FindsBy(How = How.Id, Using = "age")]
        private readonly IWebElement _popupAgeField = null!;

        [FindsBy(How = How.Id, Using = "salary")]
        private readonly IWebElement _popupSalaryField = null!;

        [FindsBy(How = How.Id, Using = "department")]
        private readonly IWebElement _popupDepartmentField = null!;

        [FindsBy(How = How.Id, Using = "submit")]
        private readonly IWebElement _popupSubmitButton = null!;

        [FindsBy(How = How.ClassName, Using = "modal-content")]
        private readonly IWebElement _registrationFormModal = null!;

        [FindsBy(How = How.XPath, Using = "//select[@aria-label='rows per page']")]
        private readonly IWebElement _rowsPerPageSelect = null!;

        private readonly string _emptyRowsXpath = "//div[contains(@class, 'rt-tr -padRow')]";

        public WebTablesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void ClickOnAddButton()
        {
            _addButton.Click();
        }

        public void EnterFirstName(string firstName)
        {
            _popupFirstNameField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _popupLastNameField.SendKeys(lastName);
        }

        public void EnterEmail(string email)
        {
            _popupEmailField.SendKeys(email);
        }

        public void EnterAge(string age)
        {
            _popupAgeField.SendKeys(age);
        }

        public void EnterSalary(string salary)
        {
            _popupSalaryField.SendKeys(salary);
        }

        public void EnterDepartament(string departament)
        {
            _popupDepartmentField.SendKeys(departament);
        }

        public void ClickOnPopupSubmitButton()
        {
            _popupSubmitButton.Click();
        }

        public void PopulateRegistrationForm(string firstName, string lastName, string email, string age, string salary, string departament)
        {
            _popupFirstNameField.SendKeys(firstName);
            _popupLastNameField.SendKeys(lastName);
            _popupEmailField.SendKeys(email);
            _popupAgeField.SendKeys(age);
            _popupSalaryField.SendKeys(salary);
            _popupDepartmentField.SendKeys(departament);
        }

        public bool IsRegistrationFormModalDisplayed()
        {
            try
            {
                return _registrationFormModal.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetCellTextBasedOnTheColumnNameAndRow(int rowIndex, string cellName)
        {
            var columnMapping = new Dictionary<string, int>
            {
                { "First Name", 1 },
                { "Last Name", 2 },
                { "Age", 3 },
                { "Email", 4 },
                { "Salary", 5 },
                { "Department", 6 }
            };

            if (!columnMapping.TryGetValue(cellName, out var cellIndex))
            {
                throw new NoSuchElementException($"No such cell with the name '{cellName}', please select another cell name.");
            }

            return GetCellInRowAndColumn(rowIndex, cellIndex).Text;
        }

        private IWebElement GetCellInRowAndColumn(int rowIndex, int columnIndex)
        {
            return _driver.FindElement(By.XPath($"//div[@class='rt-tr-group'][{rowIndex}]//div[@class='rt-td'][{columnIndex}]"));
        }

        public int GetNumberOfRowsSelected()
        {
            SelectElement select = new(_rowsPerPageSelect);
            IWebElement selectedOption = select.SelectedOption;
            int numberOfRows = int.Parse(selectedOption.GetDomAttribute("value"));
            return numberOfRows;
        }

        public int GetNumberOfInsertedRows()
        {
            var rowsElements = _driver.FindElements(By.XPath(_emptyRowsXpath));

            return GetNumberOfRowsSelected() - rowsElements.Count;
        }


    }
}
