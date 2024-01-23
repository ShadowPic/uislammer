Feature: Testing Playwright with SpecFlow

Scenario: Demonstration of simple navigating to website and click case
  Given I navigate to the website
  When I click the "Xbox" link
  Then I should see the title "Xbox Official Site: Consoles, Games, and Community | Xbox"

Scenario: Demonstration of using POM with single and list of elements
  Given I navigate to the website
  When I Get all the menu buttons from header and click a random button
  Then I Navigate back to home page
  And I click on Microsoft logo