using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using QaTestTaskCRM.Configuration;
using System.Drawing;

namespace QaTestTaskCRM.Infrastructure
{
    [Binding]
    internal class TestBase
    {
        public static IWebDriver WebDriver { get; private set; }

        private static TestsConfiguration _config;

        public static TestsConfiguration GetTestsConfiguration()
            => _config;

        [BeforeScenario]
        public static void BeforeTestRun()
        {
            WebDriver = new EdgeDriver();
            _config = new TestsConfiguration();
            //WebDriver.Navigate().GoToUrl(_config.HostUrl);
            WebDriver.Navigate().GoToUrl("https://demo.1crmcloud.com/");
            // Screen size for most popular screen size
            WebDriver.Manage().Window.Size = new Size(1920, 1080);

            // TODO: Recheck if this will be fine wait method
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            WebDriver.Quit();
        }

    }
}
