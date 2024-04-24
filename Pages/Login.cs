using Microsoft.Playwright;
using playwrightSolution.Helpers;
using static Microsoft.Playwright.Assertions;


namespace playwrightSolution.Pages
{
    public class Login
    {
        private readonly IPage Page;
        public Login(IPage Page)
        {
            this.Page = Page;
        }
        public ILocator UserName => Page.GetByPlaceholder("Username");
        public ILocator Password => Page.GetByPlaceholder("Password");
        public ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Login" });

        public ILocator Dashboard => Page.GetByRole(AriaRole.Link, new() { Name = "Dashboard" });

        private async Task navigateToSite()
        {
            string url = CommonUtility.GetAValueFromAppSettings("APPURL");
            await Page.GotoAsync(url);
        }
        public async Task LoginToSite()
        {
            await navigateToSite();

            await UserName.FillAsync("Admin");
            await Password.FillAsync("admin123");
            await LoginButton.ClickAsync();
            await Expect(Dashboard).ToBeVisibleAsync();
        }
    }
}
