using Microsoft.Playwright;
using NUnit.Framework;
using playwrightSolution.Constants;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace playwrightSolution.Setup
{
    [Binding]
    public class Hooks 
    {
        public IPage _PlaywrightPage = null!;

        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        } 

        [BeforeScenario]
        public async Task GetPlaywrightInstance()
        {
            _PlaywrightPage = await PlaywrightBase.InitializePlaywright();
        }


        /// <summary>
        /// 1) Takes screen shot if there is a failure in any SpecFlow scenario 
        /// 2) Screen shots are stored in ProjectFolder\bin\Debug\net8.0\TestOutput\Screenshots
        /// </summary>
        /// <returns></returns>
        [AfterScenario]
        public async Task TearDown()
        {
            if (Config.TakeScreenShot == true || _scenarioContext.ScenarioExecutionStatus.ToString().Equals("TestError"))
            {
                 await PlaywrightBase.TakeScreenShot(_PlaywrightPage, _scenarioContext.ScenarioInfo.Title);
            }
            await PlaywrightBase.CleanupPlaywright(_PlaywrightPage);

        }

    }
}
