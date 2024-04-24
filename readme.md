# uislammer
collaboration to streamline and enhance ui automation using C# and Playwright

# Project setup 
- Clone the repo and Open the solution in Visual Studio
- Build the solution
- Open Test Explorer
- Select existing demo test 
- Click on Run Selected Tests

# How to create new test in Nunit format


# How to create new test in BDD format
- Create a new feature file under SpecFlowBDDStyleTests folder
- Add a new scenario in the feature file following GHERKIN
	- GIVEN (describing the context)
	- WHEN (describing the action)
	- THEN (describing the outcome)
- Now define all the step definitions in a new or existing StepDefinition.cs file
- Run the test via Test Explorer or command line

# How to create new test in NUnit

# Reporting 

## Allure Reporting 
- We have to use Allure tags on the test cases / feature file to see them in allure report
- Results are generated in `allure-results` folder under bin\Debug\net8.0
- To see the results run the allure serve command in the terminal from this folder bin\Debug\net8.0

refer  https://allurereport.org/docs/specflow/  or https://allurereport.org/docs/nunit/ for more details
