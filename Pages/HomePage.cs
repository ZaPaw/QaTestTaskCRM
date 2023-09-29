using OpenQA.Selenium;

namespace QaTestTaskCRM.Pages
{
    internal class HomePage : BasePage
    {
        private static readonly By _userNameInputBy = By.CssSelector("li[data-tab-id='LBL_TABGROUP_SALES_MARKETING']");
        private static readonly By _menuPopupElement = By.Id("menu-source-2-popup");
        private static readonly By _contactsModuleBtn = By.CssSelector("div[class='module-Contacts']");
        private static readonly string _partialUrl = "index.php";

        public HomePage() : base(_partialUrl)
        {

        }
    }
}
