

using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using playwright.Pages;

namespace playwright.NUnitTests.Tests
{
    [Parallelizable(ParallelScope.Self)]
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

