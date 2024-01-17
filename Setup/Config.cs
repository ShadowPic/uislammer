using Microsoft.Playwright;

namespace playwrightBDD.Setup
{
    public class Config
    {
        public static bool HEADLESS = Convert.ToBoolean(CommonUtil.GetAValueFromAppSettings("Playwright:LaunchOptions:Headless"));
        public static string CHANNEL = CommonUtil.GetAValueFromAppSettings("Playwright:LaunchOptions:Channel");
        public static string ENVIRONMENT = CommonUtil.GetAValueFromAppSettings("environment");
        public static bool TakeScreenshot = Convert.ToBoolean(CommonUtil.GetAValueFromAppSettings("TakeScreenshot"));
    } 
}

