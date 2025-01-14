using AutomationProject_NET.AutomationFramework.Pages;
using AutomationProject_NET.AutomationFramework.Pages.Elements;
using AutomationProject_NET.AutomationFramework.Pages.Forms;

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

        [SetUp]
        public void SetUpPages()
        {
            homePage = new HomePage(Driver);
            elementsPage = new ElementsPage(Driver);
            textBoxPage = new TextBoxPage(Driver);
            webTablesPage = new WebTablesPage(Driver);
            formsPage = new FormsPage(Driver);
            practiceFormsPage = new PracticeFormPage(Driver);
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
            string firstName = "Maria";
            string lastName = "Ioana";
            string email = "maria.ioana@test.com";
            string age = "50";
            string salary = "5000";
            string departament = "HR";

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
    }
}