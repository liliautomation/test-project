@e2eTest @webTest
Feature: Track todo list

Background:
	Given I have a web application 'https://todomvc.com/examples/angularjs/#/' to help me track the todo list

Scenario Outline: Add an item to my todo list
	When I add an <item> to my todo list
	Then I should see the <item> in my active todo list
	And I should be able to see it as active in the 'Active' tasks list

	Examples:
		| item                   |
		| build a test framework |

Scenario Outline: Mark an item as complete
	When I mark an <item> on my todo list as complete
	Then I should see the <item> in my complete list
	And I should be able to see it as complete in the 'Complete' tasks list

	Examples:
		| item            |
		| complete a task |