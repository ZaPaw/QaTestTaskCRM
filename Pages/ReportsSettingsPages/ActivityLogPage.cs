using OpenQA.Selenium;
using QaTestTaskCRM.Support;

namespace QaTestTaskCRM.Pages.ReportsSettingsPages
{
    internal class ActivityLogPage : BasePage
    {
        private static readonly string _partialUrl = "index.php?module=ActivityLog&action=index";
        private static readonly By _tableBy = By.TagName("table");
        private static readonly By _actionsButtonBy = By.CssSelector("[id$=ActionButtonHead]");
        private static readonly By _actionsButtonPopupBy = By.CssSelector("[id$=ActionButtonHead-popup]");
        private static readonly By _listViewStatutsBy = By.ClassName("listview-status");

        public ActivityLogPage() : base(_partialUrl)
        {

        }

        public int GetActivitysCount()
        {
            string countText = WebDriver.GetElement(_listViewStatutsBy).FindElements(By.ClassName("text-number"))[1].Text;
            countText = new String(countText.Where(Char.IsDigit).ToArray());
            return Int16.Parse(countText);
        }

        public void ClickActionsDelete()
        {
            WebDriver.Click(_actionsButtonBy);
            WebDriver.GetElement(_actionsButtonPopupBy).GetElementFromParent(By.XPath("//*[text()='Delete']")).Click();
            WebDriver.SwitchTo().Alert().Accept();
        }

        public void SelectItemsInTable(int numberOfItems)
        {
            IWebElement table = WebDriver.GetElement(_tableBy);

            for (int i = 0; i < numberOfItems; i++)
            {
                table.FindElements(By.TagName("tr"))[i + 1].FindElement(By.TagName("input")).Click();
            }
        }
    }
}
