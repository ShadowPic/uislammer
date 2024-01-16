using Microsoft.Extensions.Configuration;

namespace playwrightBDD.Setup
{
    public class CommonUtil
    {
        static IConfiguration? _config;
        public static string GetAValueFromAppSettings(string key)
        {
            if (string.IsNullOrEmpty(Configuration[key]))
            {
                throw new System.ArgumentException($"the key is not found in congiuration please check the appsettings.json or appsettings.{Config.ENVIRONMENT}.json file for ", key);
            }
            return Configuration[key]!;
        }

        
        public static IConfiguration Configuration
        {
            get
            {

                if (_config == null)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{Config.ENVIRONMENT}.json", false, true)
                        .AddJsonFile("appsettings.local.json", false, true)
                        .AddXmlFile("PlaywrightBDDRunSettings.runsettings", false, true);
                    _config = builder.Build();
                }

                return _config;
            }
        }

        private static readonly Random random = new();
        public static int GetARandomNumberWithinRange(int start, int end)
        {
            return random.Next(start, end + 1);
        }
    }
}
