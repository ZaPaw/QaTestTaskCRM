using OpenQA.Selenium;
using QaTestTaskCRM.Infrastructure;
using QaTestTaskCRM.Support;

namespace QaTestTaskCRM.Pages
{
    internal abstract class BasePage
    {

        public static IWebDriver WebDriver => TestBase.WebDriver;

        public string PartialUrl { get; private set; }

        private static readonly string _hostUrl = "https://demo.1crmcloud.com/";

        public BasePage(string partialUrl)
        {
            PartialUrl = partialUrl;
        }

        public void OpenPage()
        {
            var url = GetPageUrl(PartialUrl);
            WebDriver.Navigate().GoToUrl(url);
        }

        public string GetPageUrl(string partialUrl)
        {
            return $"{_hostUrl}{partialUrl}";
        }

        public void WaitForThePageToChange(int secondsToWait = 120)
        {
            WebDriver.WaitForThePageToChange(PartialUrl, secondsToWait);
        }
        public void RefreshPage()
        {
            WebDriver.Navigate().Refresh();
        }
    }
}
