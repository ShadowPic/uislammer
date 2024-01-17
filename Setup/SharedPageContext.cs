    using PlaywrightTestsCsNunit.Constants;

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
            scenarioVideoFolderPath = $"./TestOutput_{RunConstants.ENVIRONMENT}_env/videos/{scenarioTitle.ToString().Replace(" ", "")}/";
            var playwright = await Playwright.CreateAsync();

            
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = RunConstants.HEADLESS,
                Args = new string[] { "--start-maximized" },
                Channel = CommonUtil.WhichBrowserToRun(),

            });

            //Setup a browser context
            browserContext = await browser.NewContextAsync(new()
            {
                ViewportSize = BrowserConstants.StandardViewPortSize,
                //ViewportSize = ViewportSize.NoViewport
                //RecordVideoDir = scenarioVideoFolderPath,

            });
            //Initialise a page on the browser context.
            PlaywrightPage = await browserContext.NewPageAsync();
            await PlaywrightPage.SetViewportSizeAsync(1920, 945);
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
