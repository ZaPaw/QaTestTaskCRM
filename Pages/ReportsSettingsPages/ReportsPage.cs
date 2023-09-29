using OpenQA.Selenium;
using QaTestTaskCRM.Support;

namespace QaTestTaskCRM.Pages.ReportsSettingsPages
{
    internal class ReportsPage : BasePage
    {
        private static readonly string _partialUrl = "?module=Reports&action=index";
        private static readonly By _reportsFilterBy = By.Id("filter_text");
        private static readonly By _listViewNameLinkBy = By.ClassName("listViewNameLink");
        private static readonly By _runReportButtonBy = By.Name("FilterForm_applyButton");
        private static readonly By _listViewBy = By.ClassName("listView");

        public ReportsPage() : base(_partialUrl)
        {

        }

        public void LookingForGivenReport(string reportName)
        {
            WebDriver.GetElement(_reportsFilterBy).SetValueToInput(reportName);
            WebDriver.GetElement(_reportsFilterBy).SendKeys(Keys.Enter);
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(1000);
            WebDriver.Click(_listViewNameLinkBy);
        }

        public void RunReport()
        {
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(2000);
            WebDriver.Click(_runReportButtonBy);
        }

        public string GetListViewText()
        {
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(2000);
            return WebDriver.GetElement(_listViewBy).Text;
        }
    }
}
