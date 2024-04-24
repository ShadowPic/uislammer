

using Allure.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using playwrightSolution.Setup;


namespace playwrightSolution.NUnitTests.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [AllureNUnit]
    public class NUnitBase
    {
        public IPage Page;

        [SetUp]
        public async Task BeforeTest()
        {
            Page = await PlaywrightBase.InitializePlaywright();
        }

        [TearDown]
        public async Task AfterTest()
        {
            await PlaywrightBase.CleanupPlaywright(Page);
        }


    }
}

