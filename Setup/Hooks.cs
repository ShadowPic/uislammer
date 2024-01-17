using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.Common;
using NUnit.Framework;
using System.Text;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace playwrightBDD.Setup
{
    [Binding]
    public sealed class Hooks :BaseStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        public IPage _Page;
        public IPage CurrentPage { get { return _Page; } }

        SharedPageContext sharedPageContext = new();
        public IPage currentPage { get { return base.PlaywrightPage; } }
        [BeforeScenario]
        public async Task RegisterSingleInstancePractitioner()
        {
            base.CleanupPlaywright();
            await base.InitializePlaywright();
        }


        /// <summary>
        /// 1) Takes screenshot if there is a failure in any SpecFlow scenario 
        /// 2) Screenshots are stored in ProjectFolder\bin\Debug\net7.0\TestOutput\Screenshots
        /// </summary>
        /// <returns></returns>
        [AfterScenario]
        public async Task TearDown()
        {
            if (Config.TakeScreenshot == true || _scenarioContext.ScenarioExecutionStatus.ToString().Equals("TestError"))
            {
                string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");

                await _Page.ScreenshotAsync(new()
                {
                    Path = $"TestOutput_{Config.ENVIRONMENT}_env/Screenshots/" + "_" + _scenarioContext.ScenarioInfo.Title + "_" + currentDateTime + ".jpg",
                    FullPage = true,
                });
            }
            await sharedPageContext.DestroyPlaywrightPage();

        }

    }
}
