using OpenQA.Selenium;
using QaTestTaskCRM.Support;
namespace QaTestTaskCRM.Pages.SalesMarketingPages
{
    internal class ContactDetailViewPage : BasePage
    {
        private static readonly string _partialUrl = "?module=Contacts&action=DetailView&record=";
        private static readonly By _deleteButtonBy = By.Id("DetailForm_delete");
        private static readonly By _titleBy = By.Id("_form_header");
        private static readonly By _detailFormBy = By.Id("DetailForm");

        public ContactDetailViewPage() : base(_partialUrl)
        {

        }

        public string GetTitleText()
        {
            return WebDriver.GetElement(_titleBy).Text;
        }

        public string GetDetailFormText()
        {
            return WebDriver.GetElement(_detailFormBy).Text;
        }

        public void ClickDeleteContact()
        {
            WebDriver.Click(_deleteButtonBy);
            WebDriver.SwitchTo().Alert().Accept();
        }
    }
}
