using NUnit.Framework;
using playwrightSolution.Pages;
using Allure.NUnit.Attributes;


namespace playwrightSolution.NUnitTests.Tests
{
    [TestFixture]
    public class HomePageTest : NUnitBase
    {

        public required Login login;
        
        // common method to initialize objects etc


        [Category("Gaurav")]
        [Category("US_12345")]
        [Category("TC_12398")]
        [Test]
        [AllureEpic("UserManagement")]
        [AllureFeature("SignIn")]
        [AllureSuite("Gaurav")]
        public async Task Validate_UserCanLogin()
        {
            login = new Login(Page);
            await login.LoginToSite();
        }

    }
}
