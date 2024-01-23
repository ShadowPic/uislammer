using Microsoft.Playwright;
using playwrightBDD.Setup;


public class PlaywrightBase
{
    public IBrowser browser = null!;
    public IBrowserContext browserContext = null!;
    public IPage PlaywrightPage = null!;

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

    public static async Task TakeScreenShot(IPage PlaywrightPage,string title)
    {
        string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");

        await PlaywrightPage.ScreenshotAsync(new()
        {
            Path = $"TestOutput_{Config.ENVIRONMENT}_env/Screenshots/" + "_" + title + "_" + currentDateTime + ".jpg",
            FullPage = true,
        });
    }
}