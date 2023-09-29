using OpenQA.Selenium;
using QaTestTaskCRM.Support;

namespace QaTestTaskCRM.Pages.SalesMarketingPages
{

    internal class CreateContactPage : BasePage
    {
        private static readonly string _partialUrl = "index.php?module=Contacts&action=EditView&record=&return_module=Contacts&return_action=DetailView";
        private static readonly By _firstNameInputBy = By.Id("DetailFormfirst_name-input");
        private static readonly By _lastNameInputBy = By.Id("DetailFormlast_name-input");
        private static readonly By _businessRoleInputBy = By.Id("DetailFormbusiness_role-input");
        private static readonly By _businessRolePopupBy = By.Id("DetailFormbusiness_role-input-popup");
        private static readonly By _categoryInputBy = By.Id("DetailFormcategories-input");
        private static readonly By _categoryInputSearchBy = By.Id("DetailFormcategories-input-search");
        private static readonly By _saveButtonBy = By.Id("DetailForm_save");

        public CreateContactPage() : base(_partialUrl)
        {

        }

        public void SetFirstName(string firstName)
        {
            WebDriver.FindElement(_firstNameInputBy).SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            WebDriver.FindElement(_lastNameInputBy).SendKeys(lastName);
        }

        // Assumed that "Role" = "Business Role"
        public void SetBusinessRole(string role)
        {
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(1000);
            WebDriver.Click(_businessRoleInputBy);
            WebElement ele = (WebElement)WebDriver.GetElement(_businessRolePopupBy);
            ele = (WebElement)ele.GetElementFromParent(By.XPath("//*[text()='" + role + "']"));
            WebDriver.Click(ele);
        }

        public void SetCategory(string category)
        {
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(1000);
            WebDriver.Click(_categoryInputBy);
            WebElement ele = (WebElement)WebDriver.GetElement(_categoryInputSearchBy);
            ele = (WebElement)ele.GetElementFromParent(By.XPath("//*[text()='" + category + "']"));
            WebDriver.Click(ele);
        }

        public void ClickSaveButton()
        {
            WebDriver.Click(_saveButtonBy);
        }
    }
}
