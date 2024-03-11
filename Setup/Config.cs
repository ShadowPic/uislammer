using Microsoft.Playwright;
using NUnit.Framework;
using playwright.Helpers;

namespace playwrightBDD.Setup
{
    public class Config
    {
        public static readonly string ENVIRONMENT = TestContext.Parameters["environment"]!;
        public static readonly bool HEADLESS = Convert.ToBoolean(CommonUtility.GetAValueFromAppSettings("Playwright:LaunchOptions:Headless"));
        public static readonly bool TakeScreenShot = Convert.ToBoolean(CommonUtility.GetAValueFromAppSettings("Settings:TakeScreenShot"));
    } 
}

