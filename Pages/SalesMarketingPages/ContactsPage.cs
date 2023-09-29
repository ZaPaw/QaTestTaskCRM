using OpenQA.Selenium;

namespace QaTestTaskCRM.Pages
{
    internal class ContactsPage : BasePage
    {
        private static readonly string _partialUrl = "index.php?module=Contacts&action=index";
        private static readonly By _leftSidebarBy = By.Id("left-sidebar");

        public ContactsPage() : base(_partialUrl)
        {

        }

        public void ClickButtonInLeftSidebar(string buttonText)
        {
            WebDriver.FindElement(_leftSidebarBy).FindElement(By.LinkText(buttonText)).Click();
        }
    }
}
