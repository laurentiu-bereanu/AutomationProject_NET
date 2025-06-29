using AutomationProject_NET.AutomationFramework.Access;
using AutomationProject_NET.AutomationFramework.Configuration;
using AutomationProject_NET.AutomationFramework.Pages;
using AutomationProject_NET.AutomationFramework.Pages.AlertsFrameWindows;
using AutomationProject_NET.AutomationFramework.Pages.Elements;
using AutomationProject_NET.AutomationFramework.Pages.Forms;
using AutomationProject_NET.AutomationFramework.Pages.Interactions;
using AutomationProject_NET.AutomationFramework.Utils;

namespace AutomationProject_NET.AutomationFramework.Tests
{
    public class DemoQaTests : BaseTest
    {

        private HomePage homePage = null!;
        private ElementsPage elementsPage = null!;
        private TextBoxPage textBoxPage = null!;
        private WebTablesPage webTablesPage = null!;
        private FormsPage formsPage = null!;
        private PracticeFormPage practiceFormsPage = null!;
        private InteractionsPage interactionsPage = null!;
        private SelectablePage selectablePage = null!;
        private AlertsFrameWindowsPage alertsFrameWindowsPage = null!;
        private FramesPage framesPage = null!;
        private ContextMethods contextMethods = null!;
        private CommonPage commonPage = null!;
        private FramesCursPage framesCursPage = null!;

        [SetUp]
        public void SetUpPages()
        {
            homePage = new HomePage(Driver);
            elementsPage = new ElementsPage(Driver);
            textBoxPage = new TextBoxPage(Driver);
            webTablesPage = new WebTablesPage(Driver);
            formsPage = new FormsPage(Driver);
            practiceFormsPage = new PracticeFormPage(Driver);
            interactionsPage = new InteractionsPage(Driver);
            selectablePage = new SelectablePage(Driver);
            alertsFrameWindowsPage = new AlertsFrameWindowsPage(Driver);
            framesPage = new FramesPage(Driver);
            contextMethods = new ContextMethods(Driver);
            commonPage = new CommonPage(Driver);
            framesCursPage = new FramesCursPage(Driver);
        }

        [Test]
        public void ValidateTextBoxOutputAfterFormSubmission()
        {
            string fullName = "John Doe";
            string email = "johndoe@johndoe.ro";
            string currentAddress = "Square Union Street No 11";
            string permanentAddress = "Triangle Union Street No 14";

            homePage.ClickOnElementsSection();
            Assert.That(elementsPage.IsAt(), Is.True);

            elementsPage.NavigateToTextBox();
            Assert.That(textBoxPage.IsAt(), Is.True);

            textBoxPage.PopulateFormWithData(fullName, email, currentAddress, permanentAddress);

            textBoxPage.ClickOnSubmitButton();

            Assert.Multiple(() =>
            {
                Assert.That(textBoxPage.GetOutputNameText(), Is.EqualTo($"Name:{fullName}"));
                Assert.That(textBoxPage.GetOutputEmailText(), Is.EqualTo($"Email:{email}"));
                Assert.That(textBoxPage.GetOutputCurrentAddressText(), Is.EqualTo($"Current Address :{currentAddress}"));
                Assert.That(textBoxPage.GetOutputPermanentAddressText(), Is.EqualTo($"Permananet Address :{permanentAddress}"));
            });

        }

        [Test]
        public void ShouldAddRecordToWebTable()
        {
            var webTableData = new WebTableData(1);
            string firstName = webTableData.FirstName;
            string lastName = webTableData.LastName;
            string email = webTableData.UserEmail;
            string age = webTableData.Age;
            string salary = webTableData.Salary;
            string departament = webTableData.Department;

            homePage.ClickOnElementsSection();
            Assert.That(elementsPage.IsAt(), Is.True);
            elementsPage.NavigateToWebTables();
            Assert.That(webTablesPage.IsAt(), Is.True);

            var numberOfRecordsBeforeInsert = webTablesPage.GetNumberOfInsertedRows();

            webTablesPage.ClickOnAddButton();
            Assert.That(webTablesPage.IsRegistrationFormModalDisplayed(), Is.True);

            webTablesPage.PopulateRegistrationForm(firstName, lastName, email, age, salary, departament);
            webTablesPage.ClickOnPopupSubmitButton();

            Assert.That(webTablesPage.GetNumberOfInsertedRows(), Is.EqualTo(numberOfRecordsBeforeInsert + 1));

            var rowIndex = webTablesPage.GetNumberOfInsertedRows();

            Assert.Multiple(() =>
            {
                Assert.That(webTablesPage.GetCellTextBasedOnTheColumnNameAndRow(rowIndex, "First Name"), Is.EqualTo($"{firstName}"));
                Assert.That(webTablesPage.GetCellTextBasedOnTheColumnNameAndRow(rowIndex, "Last Name"), Is.EqualTo($"{lastName}"));
                Assert.That(webTablesPage.GetCellTextBasedOnTheColumnNameAndRow(rowIndex, "Age"), Is.EqualTo($"{age}"));
                Assert.That(webTablesPage.GetCellTextBasedOnTheColumnNameAndRow(rowIndex, "Email"), Is.EqualTo($"{email}"));
                Assert.That(webTablesPage.GetCellTextBasedOnTheColumnNameAndRow(rowIndex, "Salary"), Is.EqualTo($"{salary}"));
                Assert.That(webTablesPage.GetCellTextBasedOnTheColumnNameAndRow(rowIndex, "Department"), Is.EqualTo($"{departament}"));
            });
        }

        [Test]
        public void PracticeFormTest()
        {
            homePage.ClickOnFormsSection();
            Assert.That(formsPage.IsAt(), Is.True);

            formsPage.NavigateToPracticeForm();
            Assert.That(practiceFormsPage.IsAt(), Is.True);

            practiceFormsPage.SelectGender("male");
            practiceFormsPage.EnterSubject("English");
        }

        [Test]
        public void PracticeFormTestWithTestData()
        {
            PracticeFormData practiceFormData = new PracticeFormData(1);

            homePage.ClickOnFormsSection();
            Assert.That(formsPage.IsAt(), Is.True);

            formsPage.NavigateToPracticeForm();
            Assert.That(practiceFormsPage.IsAt(), Is.True);

            practiceFormsPage.PopulateStudentRegistrationForm(practiceFormData);

            practiceFormsPage.SubmitForm();
        }
       

        [Test]
        public void SelectableTest()
        {
            homePage.ClickOnInteractionsSection();
            Assert.That(interactionsPage.IsAt(), Is.True);

            interactionsPage.NavigateToSelectable();
            Assert.That(selectablePage.IsAt(), Is.True);

            selectablePage.ClickOnGridView();

            selectablePage.ClickOnlyOnCellsWithSpecificType("odd");
        }

        [Test]
        public void InteractWithFrames()
        {
            homePage.ClickOnAlertsFrameWindowsSection();
            Assert.That(alertsFrameWindowsPage.IsAt(), Is.True);

            alertsFrameWindowsPage.NavigateToFrames();
            Assert.That(framesPage.IsAt(), Is.True);

            framesPage.SwitchToBigFrameContext();
            LoggerHelper.Log.Info(framesPage.GetBigFrameText());

            contextMethods.SwitchToDefaultContext();

            framesPage.SwitchToSmallFrameContext();
        }

        [Test]
        public void FrameTest()
        {
            homePage.ClickOnAlertsFrameWindowsSection();
            commonPage.GoToDesiredSubMenu("Frames");
            framesCursPage.GetTextFromBigFrame();

            framesCursPage.GetTextFromSmallFrame();
        }
    }
}