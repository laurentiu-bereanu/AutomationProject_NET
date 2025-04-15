using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AutomationProject_NET.AutomationFramework.Utils;

namespace AutomationProject_NET.AutomationFramework.Pages.Forms
{
    public class FormsPage : BasePage
    {
        private readonly ElementMethods _elementMethods;

        protected override string PageUrl => "/forms";

        [FindsBy(How = How.XPath, Using = "//*[text()='Practice Form']")]
        private readonly IWebElement _practiceFormButton = null!;

        public FormsPage(IWebDriver driver) : base(driver) 
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }


        public void NavigateToPracticeForm()
        {
            _elementMethods.ClickElement(_practiceFormButton);
        }
    }
}
