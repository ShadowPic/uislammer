
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using playwrightBDD.Setup;
using System.Text.RegularExpressions;

namespace playwright.Helpers
{
    public class CommonUtility
    {
        static IConfiguration? _config;

        //This function will return the value for a given key in appsettings
        public static string GetAValueFromAppSettings(string key)
        {
            if (string.IsNullOrEmpty(Configuration[key]))
            {
                throw new ArgumentException($"the key is not found in configuration please check the appsettings.json or appsettings.{Config.ENVIRONMENT}.json file for ", key);
            }
            return Configuration[key]!;
        }

        // This function will return all the configuration values from all the settings file
        public static IConfiguration Configuration
        {
            get
            {

                if (_config == null)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile("appsettings.local.json", false, true)
                        .AddJsonFile($"appsettings.{Config.ENVIRONMENT}.json", false, true)
                        .AddXmlFile("PlaywrightRunSettings.runsettings", false, true);
                    _config = builder.Build();
                }

                return _config;
            }
        }

        // This function will return a random number between the given range
        private static readonly Random random = new();

        public static int GetARandomNumberWithinRange(int start, int end)
        {
            return random.Next(start, end + 1);
        }

        // This function will return a random string of given length
        public static string GetARandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                                         .Select(c => chars[random.Next(chars.Length)])
                                         .ToArray());
        }

        // This method will return the current date time in the given time zone
        public static DateTime GetCurrentDate(string timeZone)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
            return datetime;
        }

        // This method will return Base64 encoded string for the given plain text. This can be used when dealing with secrets or passwords
        public static string EncodeToBase64(string plainText)
        {
            plainText = ":" + plainText;
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string encodedText = Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }

        // This function will return the string after removing all the special characters
        public static string RemoveSpecialCharacters(string inputStringWithSpecialChar)
        {
            // Define a regular expression pattern for special characters
            string pattern = "[^a-zA-Z0-9]";

            // Create a Regex object
            Regex regex = new(pattern);

            // Use the Regex.Replace method to remove special characters
            string result = regex.Replace(inputStringWithSpecialChar, "");

            return result;
        }

        //This function will return all the tokens for a given property in json
        public static JToken GetTokensForProperty(string PropertyName)
        {
            // read app settings file as string
            var json = File.ReadAllText($"appsettings.{Config.ENVIRONMENT}.json");

            // convert string json into a JToken for the given property and return
            return JObject.Parse(json)[PropertyName]!;
        }


    }
}
