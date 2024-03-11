using Microsoft.Playwright;
using NUnit.Framework;
using playwright.Pages;


namespace playwright.NUnitTests.Tests
{
    [TestFixture]
    public class HomePageTest : NUnitBase
    {

        public required Login login;
        
        // common method to initialize objects etc
        public void beforeClass(IPage page)
        {
            login = new Login(page);
        }

        [Category("Gaurav")]
        [Category("US_12345")]
        [Category("TC_12398")]
        [Test]
        public async Task Validate_UserCanLogin()
        {
            beforeClass(Page);
            Login login = new Login(Page);
            await login.LoginToSite();
        }

    }
}
