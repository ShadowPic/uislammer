using Microsoft.Playwright;

namespace playwrightBDD.Setup
{
    public class SharedPageContext
    {
        public IPage PlaywrightPage = null!;
        public IBrowser browser = null!;
        public IBrowserContext browserContext = null!;


        public bool AuthenticationContextSaved = false;
        public string? scenarioVideoFolderPath;

        public async Task<IPage> CreateNewPlaywrightPage(string scenarioTitle)
        {
             var playwright = await Playwright.CreateAsync();
            
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = Config.HEADLESS,
                Args = new string[] { "--start-maximized" },
                Channel = Config.CHANNEL,

            });

            //Setup a browser context
            browserContext = await browser.NewContextAsync(new());

            //Initialize a page on the browser context.
            PlaywrightPage = await browserContext.NewPageAsync();            
            return PlaywrightPage;
        }

        public IAPIRequestContext? GetApiContext()
        {
            if (AuthenticationContextSaved)
            {

                return PlaywrightPage.APIRequest;
            }
            return null;
        }

        public async Task DestroyPlaywrightPage()
        {

            await PlaywrightPage.CloseAsync();
            await browserContext.CloseAsync();
            await browser.CloseAsync();

        }
    }

}
