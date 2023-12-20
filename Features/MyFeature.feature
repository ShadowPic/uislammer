Feature: Testing Playwright with SpecFlow

Scenario: Verify website title
Given I navigate to the website
When I click the "Xbox" link
Then I should see the title "Xbox Official Site: Consoles, Games, and Community | Xbox"
