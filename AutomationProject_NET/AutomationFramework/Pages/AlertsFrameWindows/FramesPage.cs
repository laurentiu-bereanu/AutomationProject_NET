using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.AlertsFrameWindows
{
    public class FramesPage : BasePage
    {
        private readonly ContextMethods _contextMethods;

        protected override string PageUrl => "/frames";

        [FindsBy(How = How.Id, Using = "frame1")]
        private readonly IWebElement _bigFrame = null!;

        [FindsBy(How = How.Id, Using = "sampleHeading")]
        private readonly IWebElement _bigFrameText = null!;

        [FindsBy(How = How.Id, Using = "frame2")]
        private readonly IWebElement _smallFrame = null!;

        public FramesPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _contextMethods = new ContextMethods(driver);
        }

        public void SwitchToBigFrameContext()
        {
            _contextMethods.SwitchToFrameContext(_bigFrame);
        }

        public void SwitchToSmallFrameContext()
        {
            _contextMethods.SwitchToFrameContext(_smallFrame);
        }

        public String GetBigFrameText()
        {
            return _bigFrameText.Text;
        }
    }
}
