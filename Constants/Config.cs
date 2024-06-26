﻿using NUnit.Framework;
using playwrightSolution.Helpers;

namespace playwrightSolution.Constants
{
    public class Config
    {
        public static readonly string ENVIRONMENT = TestContext.Parameters["environment"]!;
        public static readonly bool HEADLESS = Convert.ToBoolean(CommonUtility.GetAValueFromAppSettings("Playwright:LaunchOptions:Headless"));
        public static readonly bool TakeScreenShot = Convert.ToBoolean(CommonUtility.GetAValueFromAppSettings("Settings:TakeScreenShot"));
    }
}

