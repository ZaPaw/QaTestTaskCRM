using QaTestTaskCRM.Pages;
using QaTestTaskCRM.Pages.ReportsSettingsPages;
using QaTestTaskCRM.Pages.SalesMarketingPages;

namespace QaTestTaskCRM.StepDefinitions
{
    [Binding]
    public class CRMTestCasesStepDefinitions
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly ContactsPage salesMarketingContactsPage = new ContactsPage();
        private readonly CreateContactPage createContactPage = new CreateContactPage();
        private readonly ContactDetailViewPage contactDetailViewPage = new ContactDetailViewPage();
        private readonly ReportsPage reportsPage = new ReportsPage();
        private readonly ActivityLogPage activityLogPage = new ActivityLogPage();
        private int activitysCount;

        [Given(@"I login as Admin user")]
        public void GivenLogin()
        {
            loginPage.LoginAsAdmin();
        }

        [When(@"I navigate to “Reports & Settings” -> “Reports” page")]
        public void WhenINavigateToReportsSettings_ReportsPage()
        {
            reportsPage.OpenPage();
        }

        [When(@"I navigate to “Sales & Marketing” -> “Contacts” page")]
        public void WhenNavigateToSalesMarketing_Contacts()
        {
            salesMarketingContactsPage.OpenPage();
        }

        [When(@"I navigate to “Reports & Settings” -> “Activity log” page")]
        public void WhenINavigateToReportsSettings_ActivityLogPage()
        {
            activityLogPage.OpenPage();
        }


        [When(@"I am looking for '([^']*)' report on Reports page")]
        public void WhenIAmLookingForReportOnReportsPage(string reportName)
        {
            reportsPage.LookingForGivenReport(reportName);
        }

        [When(@"I run report")]
        public void WhenIRunReport()
        {
            reportsPage.RunReport();
        }

        [Then(@"I should see some results")]
        public void ThenIShouldSeeSomeResults()
        {
            reportsPage.GetListViewText().Should().NotBeEmpty();
        }


        [When(@"I click Create Contact button on Contacts page")]
        public void WhenIClickCreateContactButtonOnContactsPage()
        {
            salesMarketingContactsPage.ClickButtonInLeftSidebar("Create Contact");
        }

        [When(@"I set '([^']*)' in First Name on Contacts New Record page")]
        public void WhenISetInFirstNameOnContactsNewRecordPage(string firstName)
        {
            createContactPage.SetFirstName(firstName);
        }

        [When(@"I set '([^']*)' in Last Name on Contacts New Record page")]
        public void WhenISetInLastNameOnContactsNewRecordPage(string lastName)
        {
            createContactPage.SetLastName(lastName);
        }

        [When(@"I set '([^']*)' in Business Role on Contacts New Record page")]
        public void WhenISetInBuisnessRoleOnContactsNewRecordPage(string businessRole)
        {
            createContactPage.SetBusinessRole(businessRole);
        }

        [When(@"I set '([^']*)' in Category on Contacts New Record page")]
        public void WhenISetInCategoryOnContactsNewRecordPage(string category)
        {
            createContactPage.SetCategory(category);
        }

        [When(@"I click Save button on Contacts New Record page")]
        public void WhenIClickSaveButtonOnContactsNewRecordPage()
        {
            createContactPage.ClickSaveButton();
        }

        [Then(@"I should see that Contant contains '([^']*)' in Title")]
        public void ThenIShouldSeeThatContantContainsInTitle(string titlePart)
        {
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(2000);
            contactDetailViewPage.GetTitleText().Should().Contain(titlePart);
        }

        [Then(@"I should see that Contant contains '([^']*)' in Category")]
        public void ThenIShouldSeeThatContantContainsInCategory(string category)
        {
            contactDetailViewPage.GetDetailFormText().Should().Contain(category);
        }

        [Then(@"I should see that Contant contains '([^']*)' in Business role")]
        public void ThenIShouldSeeThatContantContainsInBusinessRole(string businessRole)
        {
            contactDetailViewPage.GetDetailFormText().Should().Contain(businessRole);
        }

        [Then(@"I delete Contact as cleaning part")]
        public void ThenIDeleteContactAsCleaningPart()
        {
            contactDetailViewPage.ClickDeleteContact();
        }

        [When(@"Select first (.*) items in the table")]
        public void WhenSelectFirstItemsInTheTable(int numberOfItems)
        {
            activityLogPage.SelectItemsInTable(numberOfItems);
        }

        [When(@"Click “Actions” -> “Delete”")]
        public void WhenClickActions_Delete()
        {
            activitysCount = activityLogPage.GetActivitysCount();
            activityLogPage.ClickActionsDelete();
        }

        [Then(@"Verify that items were delete")]
        public void ThenVerifyThatItemsWereDelete()
        {
            // TODO: remove this sleep
            System.Threading.Thread.Sleep(2000);
            activityLogPage.RefreshPage();
            activityLogPage.GetActivitysCount().Should().Be(activitysCount - 3);
        }

    }
}
