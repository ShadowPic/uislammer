using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using playwright.Helpers;


namespace playwright.Pages
{
    public class Login : PageTest
    {
        private new IPage Page;
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
