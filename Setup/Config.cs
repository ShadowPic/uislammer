using Microsoft.Playwright;

namespace playwrightBDD.Setup
{
    public class Config
    {
        public static bool HEADLESS = Convert.ToBoolean(CommonUtil.GetAValueFromAppSettings("Playwright:LaunchOptions:Headless"));
        public static bool ENVIRONMENT = Convert.ToBoolean(CommonUtil.GetAValueFromAppSettings("Playwright:LaunchOptions:Headless"));
    }
}
