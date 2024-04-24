using Microsoft.Playwright;
using NUnit.Framework;
using playwrightSolution.Constants;

namespace playwrightSolution.Setup
{
    public class PlaywrightBase
    {

        public static async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var context = await browser.NewContextAsync(new()
            {

            });

            return await context.NewPageAsync();


        }

        public static async Task CleanupPlaywright(IPage PlaywrightPage)
        {
            await PlaywrightPage.CloseAsync();
        }


        public static async Task TakeScreenShot(IPage PlaywrightPage, string title)
        {
            string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");

            await PlaywrightPage.ScreenshotAsync(new()
            {
                Path = $"TestOutput_{Config.ENVIRONMENT}_env/Screenshots/" + "_" + title + "_" + currentDateTime + ".jpg",
                FullPage = true,
            });
        }

        public static async Task StartTracing(IBrowserContext browserContext, string testName)
        {
            await browserContext.Tracing.StartAsync(new()
            {
                Title = testName,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        public static async Task StopTracing(IBrowserContext browserContext, string testName)
        {
            try
            {
                await browserContext.Tracing.StopAsync(new()
                {
                    Path = Path.Combine(TestContext.CurrentContext.WorkDirectory, "TestOutput/playwright-traces", $"{testName}.zip")
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error while stopping the tracing " + e.Message);
            }
        }


    }
}