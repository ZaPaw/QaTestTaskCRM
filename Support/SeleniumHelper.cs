using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QaTestTaskCRM.Support
{
    internal static class SeleniumHelper
    {
        public static void Click(this IWebDriver driver, IWebElement webElement)
        {
            SupportClick(driver, webElement);
        }

        public static void Click(this IWebDriver driver, By byMethod, int timeoutInSeconds = 20)
        {
            var webElement = SeleniumHelper.GetElement(driver, byMethod, timeoutInSeconds);
            SupportClick(driver, webElement);
        }

        // Perform Click() action on web element if can if can't use js for execute click on web element.
        // JavaScript execution is needed on some case when standard Click() not works.
        private static void SupportClick(IWebDriver driver, IWebElement webElement)
        {
            try
            {
                webElement.Click();
            }
            catch (Exception ex)
            {
                if (ex is ElementClickInterceptedException || ex is ElementNotInteractableException)
                {
                    // Sometimes needed for click, for example, in the edge on the long side
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].click();", webElement);
                    return;
                }

                throw;
            }
        }


        // Wait for web element to be visible on page then get this web element.
        public static IWebElement GetElement(this IWebDriver driver, By byMethod, int timeoutInSeconds = 20)
        {
            try
            {
                return driver.WaitForElementToBeVisible(byMethod, timeoutInSeconds);
            }
            catch (WebDriverException ex)
            {
                throw new NotFoundException($"Element not found specified byMethod: '{byMethod}'.", ex);
            }
        }

        public static IWebElement GetElementFromParent(this IWebElement parentElement, By byMethod)
        {
            try
            {
                return parentElement.FindElement(byMethod);
            }
            catch (Exception ex)
            {
                throw new NotFoundException($"Element not found specified '{byMethod}' inside parent elemetn <{parentElement}>.", ex);
            }
        }

        public static IWebElement WaitForElementToBeVisible(this IWebDriver driver, By byMethod, int timeoutInSeconds = 5)
        {
            try
            {
                return driver.GetWebDriverWait(timeoutInSeconds).Until(ExpectedConditions.ElementIsVisible(byMethod));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"element became not visible specified '{byMethod}' until timeout {timeoutInSeconds} seconds.", ex);
            }
        }

        private static WebDriverWait GetWebDriverWait(this IWebDriver driver, int seconds)
            => new WebDriverWait(driver, TimeSpan.FromMilliseconds(seconds * 1000));

        public static void SetValueToInput(this IWebElement webElement, string value)
        {
            webElement.SendKeys(value);
        }

        public static void WaitForThePageToChange(this IWebDriver driver, string pageUrlPart, int secondsToWait = 120)
        {
            int seconds = 0;
            while (driver.Url.Contains(pageUrlPart))
            {
                System.Threading.Thread.Sleep(1000);
                seconds++;
                if (seconds > secondsToWait)
                {
                    throw new InvalidOperationException($"Error! Page not changed after {seconds} seconds, expected wait was {secondsToWait} seconds");
                }
            }
        }
    }
}
