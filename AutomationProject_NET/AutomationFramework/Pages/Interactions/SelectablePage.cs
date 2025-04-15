using AutomationProject_NET.AutomationFramework.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationProject_NET.AutomationFramework.Pages.Interactions
{
    internal class SelectablePage : BasePage
    {
        private readonly ElementMethods _elementMethods;
        protected override string PageUrl => "/selectable";

        [FindsBy(How = How.Id, Using = "demo-tab-list")]
        private readonly IWebElement _listViewButton = null!;

        [FindsBy(How = How.Id, Using = "demo-tab-grid")]
        private readonly IWebElement _gridViewButton = null!;

        public SelectablePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            _elementMethods = new ElementMethods(driver);
        }

        public void ClickOnGridView()
        {
            _elementMethods.ClickElement(_gridViewButton);
        }

        public void ClickOnListView()
        {
            _elementMethods.ClickElement(_listViewButton);
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
                    _elementMethods.ScrollPageToElement(element);

                Console.WriteLine($"Clicking on cell with number {i + 1}");
                _elementMethods.ClickElement(element);
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
