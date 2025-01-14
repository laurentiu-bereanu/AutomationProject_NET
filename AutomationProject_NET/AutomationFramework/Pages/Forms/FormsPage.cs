using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Forms
{
    public class FormsPage : BasePage
    {
        protected override string PageUrl => "/forms";

        [FindsBy(How = How.XPath, Using = "//*[text()='Practice Form']")]
        private readonly IWebElement _practiceFormButton = null!;

        public FormsPage(IWebDriver driver) : base(driver) 
        {
            PageFactory.InitElements(driver, this);
        }

        public void NavigateToPracticeForm()
        {
            _practiceFormButton.Click();
        }
    }
}
