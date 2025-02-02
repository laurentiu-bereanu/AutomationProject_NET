using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Interactions
{
    internal class SelectablePage : BasePage
    {
        protected override string PageUrl => "/selectable";

        [FindsBy(How = How.Id, Using = "demo-tab-list")]
        private readonly IWebElement _listViewButton = null!;

        [FindsBy(How = How.Id, Using = "demo-tab-grid")]
        private readonly IWebElement _gridViewButton = null!;

        public SelectablePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnGridView()
        {
            _gridViewButton.Click();
        }

        public void ClickOnListView()
        {
            _listViewButton.Click();
        }

        public void ClickOnlyOnCellsWithSpecificType(String typeOfNumbers)
        {
            List<IWebElement> allRowsElements = GetAllRowElements();

            int index = typeOfNumbers.ToLower() switch
            {
                "even" => 1,
                "odd" => 0,
                _ => throw new Exception($"Unknown type '{typeOfNumbers}', please only use 'even' or 'odd'")
            };

            for (int i = index; i < allRowsElements.Count; i += 2)
            {
                var element = allRowsElements[i];
                if (!element.Displayed)
                    Utility.ScrollPageToElement(_driver, element);

                Console.WriteLine($"Clicking on cell with number {i + 1}");
                element.Click();
            }
        }

        private List<IWebElement> GetAllRowElements()
        {
            List<IWebElement> rowOneElements = [.. _driver.FindElements(By.XPath("//*[@id='row1']/li"))];
            List<IWebElement> rowTwoElements = [.. _driver.FindElements(By.XPath("//*[@id='row2']/li"))];
            List<IWebElement> rowThreeElements = [.. _driver.FindElements(By.XPath("//*[@id='row3']/li"))];

            return [.. rowOneElements, .. rowTwoElements, .. rowThreeElements];
        }
    }
}
