using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace playwrightBDD.Setup
{
    [Binding]
    public sealed class Hooks :BaseStepDefinition
    {
        public IPage currentPage { get { return base.PlaywrightPage; } }
        [BeforeScenario]
        public async Task RegisterSingleInstancePractitioner()
        {
            base.CleanupPlaywright();
            await base.InitializePlaywright();
        }
    }
}
