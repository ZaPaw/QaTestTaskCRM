Feature: CRMTestCases
TODO?? 

Background: 
	Given I login as Admin user


Scenario Outline: 1.Create contact
	When I navigate to “Sales & Marketing” -> “Contacts” page
	And I click Create Contact button on Contacts page
	And I set '<firstName>' in First Name on Contacts New Record page
	And I set '<lastName>' in Last Name on Contacts New Record page
	And I set '<businessRole>' in Business Role on Contacts New Record page
	And I set '<firstCategory>' in Category on Contacts New Record page
	And I set '<secondCategory>' in Category on Contacts New Record page
	And I click Save button on Contacts New Record page 
	Then I should see that Contant contains '<firstName>' in Title
	And I should see that Contant contains '<lastName>' in Title
	And I should see that Contant contains '<firstCategory>' in Category
	And I should see that Contant contains '<secondCategory>' in Category
	And I should see that Contant contains '<businessRole>' in Business role
	Then I delete Contact as cleaning part

Examples: 
| firstName | lastName | businessRole | firstCategory | secondCategory |
| Jan       | Kopytko  | Sales        | Customers     | Suppliers      |


Scenario: 2. Run Report
When I navigate to “Reports & Settings” -> “Reports” page
And I am looking for 'Project Profitability' report on Reports page
And I run report
Then I should see some results


Scenario: 3. Remove events from activity log
When I navigate to “Reports & Settings” -> “Activity log” page
And Select first 3 items in the table
And Click “Actions” -> “Delete”
Then Verify that items were delete