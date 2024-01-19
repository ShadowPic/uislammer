

using Microsoft.Playwright;
using NUnit.Framework;

namespace playwright.NUnitTests.Tests
{
    internal class NUnitBase
    {
        public IPage PlaywrightPage = null!;

        [SetUp]
        public async Task BeforeTest()
        {
            PlaywrightPage = await PlaywrightBase.InitializePlaywright();
        }

        [TearDown]
        public async Task AfterTest()
        {
            await PlaywrightBase.CleanupPlaywright(PlaywrightPage);
        }


    }
}

