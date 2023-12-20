using Microsoft.Playwright;
using NUnit.Framework;
using OpenAI_API;
using playwrightBDD.Setup;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace playwrightBDD.StepDefinitions
{
    [Binding]
    public class MyFeature : BaseStepDefinition
    {
        private readonly IPage _Page;
        public MyFeature(Hooks hooks)
        {
            _Page = hooks.currentPage;
        }

        [Given("I navigate to the website")]
        public async Task GivenINavigateToTheWebsite()
        {
            await _Page.GotoAsync("https://www.microsoft.com/");
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
            Assert.True(isEqual);
        }
    }

}
