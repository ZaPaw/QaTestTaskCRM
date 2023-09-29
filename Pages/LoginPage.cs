using OpenQA.Selenium;

namespace QaTestTaskCRM.Pages
{
    internal class LoginPage : BasePage
    {
        private static readonly By _userNameInputBy = By.Id("login_user");
        private static readonly By _passwordInputBy = By.Id("login_pass");
        private static readonly By _loginBtnBy = By.Id("login_button");
        private static readonly string _adminCredentianls = "admin";
        private static readonly string _partialUrl = "login.php";

        public LoginPage() : base(_partialUrl)
        {
        }

        public void LoginAsAdmin()
        {
            WebDriver.FindElement(_userNameInputBy).SendKeys(_adminCredentianls);
            WebDriver.FindElement(_passwordInputBy).SendKeys(_adminCredentianls);
            WebDriver.FindElement(_loginBtnBy).Click();
            WaitForThePageToChange();
        }
    }
}
