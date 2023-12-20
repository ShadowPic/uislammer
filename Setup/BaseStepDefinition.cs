using Microsoft.Playwright;
using TechTalk.SpecFlow;

[Binding]
public class BaseStepDefinition
{
    public IPage PlaywrightPage = null!;

    public async Task InitializePlaywright()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync(new()
        {

        });
        PlaywrightPage = await context.NewPageAsync();
    }

    public void CleanupPlaywright()
    {
        if (PlaywrightPage != null)
        {
            PlaywrightPage.CloseAsync().GetAwaiter();
            PlaywrightPage = null!;
        }
    }
}