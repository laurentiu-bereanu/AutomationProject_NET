using AutomationProject_NET.AutomationFramework.Pages;

namespace AutomationProject_NET.AutomationFramework.Tests
{
    public class TextBoxTests : BaseTest
    {

        [Test]
        public void EnterUserNameInTextBox()
        {
            var homePage = new HomePage(Driver);
            var elementsPage = new ElementsPage(Driver);
            var textBoxPage = new TextBoxPage(Driver);

            string fullName = "John Doe";
            string email = "johndoe@johndoe.ro";
            string currentAddress = "Square Union Street No 11";
            string permanentAddress = "Triangle Union Street No 14";

            homePage.ClickOnElementsSection();

            elementsPage.NavigateToTextBox();

            textBoxPage.EnterFullName(fullName);
            textBoxPage.EnterEmail(email);
            textBoxPage.EnterCurrentAddress(currentAddress);
            textBoxPage.EnterPermanentAddress(permanentAddress);
            textBoxPage.ClickOnSubmitButton();
        }
    }
}