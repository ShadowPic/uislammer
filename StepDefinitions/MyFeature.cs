using FluentAssertions;
using Microsoft.Playwright;
using playwrightBDD.Setup;
using TechTalk.SpecFlow;

namespace playwrightBDD.StepDefinitions
{
    [Binding]
    public class MyFeature 
    {
        //private readonly ScenarioContext _scenarioContext;
        public IPage _Page = null!;


        // Use below when you want to interact with one element xpath
        public ILocator MicrosoftLogo => _Page.Locator("//img[@itemprop='logo']");

        // use below when you want to interact with list of elements returned from xpath, make sure to use await, check the reference for more info
        public Task<IReadOnlyList<IElementHandle>> GetAllHeaderButtons => _Page.QuerySelectorAllAsync("//ul[@class='js-paddle-items']/li");


        public MyFeature(Hooks hooks)
        {
            _Page = hooks._PlaywrightPage;
        }

        [Given("I navigate to the website")]
        public async Task GivenINavigateToTheWebsite()
        {
            await _Page.GotoAsync("https://www.microsoft.com/");
        }

        [When(@"I Get all the menu buttons from header and click a random button")]
        public async Task WhenIGetAllTheMenuButtonsFromHeader()
        {
            // use await as shown below to call list of elements.
            var AllHeaderButtons = await GetAllHeaderButtons;
            var randomNumber = CommonUtility.GetARandomNumberWithinRange(1, AllHeaderButtons.Count-2);

            // once you get the random number use it to click on a random element in a list.
            await AllHeaderButtons[randomNumber].ClickAsync();
        }

        [Then(@"I Navigate back to home page")]
        public async Task ThenINavigateBackToHomePage()
        {
            await _Page.GoBackAsync();
        }

        [Then(@"I click on Microsoft logo")]
        public async Task ThenIClickOnMicrosoftLogo()
        {
            await MicrosoftLogo.ClickAsync();
        }

        [When("I click the (.*) link")]
        public async Task WhenIClickTheLink(string linkText)
        {
            await _Page.ClickAsync("(//a[text()=" + linkText + "])[1]");
        }

        [Then("I should see the title (.*)")]
        public async Task ThenIShouldSeeTheTitle(string expectedTitle)
        {
            var title = await _Page.TitleAsync();
            bool isEqual = expectedTitle.Contains(title);
            isEqual.Should().BeTrue();

        }
    }

}
