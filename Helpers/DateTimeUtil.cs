using FluentAssertions;

namespace playwrightSolution.Helpers
{
    internal static class DateTimeUtil
    {
        public static string GetDateTimeInFormat(string format)
        {
            return DateTime.Now.ToString(format);
        }

        public static string ConvertDateToGivenFormat(string date, string dateFormat)
        {
            DateTime dateObject = DateTime.Parse(date);
            string formattedDate = dateObject.ToString(dateFormat);
            return formattedDate;
        }

        public static string AddMonthsToCurrentDate(int months, string format)
        {
            return DateTime.Now.AddMonths(months).ToString(format);
        }

        public static DateTime AddDaysToGivenDate(DateTime InputDate, int days )
        {
            return InputDate.AddDays(days);
        }

        public static DateTime GetCurrentDate(string timeZone)
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            DateTime datetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);
            return datetime;
        }

        public static void AssertValidDate(string dateString, string format)
        {
            DateTime parsedDate;
            bool isValidDate = DateTime.TryParseExact(dateString, format, null, System.Globalization.DateTimeStyles.None, out parsedDate);
            isValidDate.Should().BeTrue($"because {dateString} should be a valid date in the format YYYY-MM-DD");
        }


        // more parameters can be added in this like months days 
        public static void DateStringIsNotMoreThan(string dateString, int years)
        {
            // Arrange
            DateTime dateToCheck = DateTime.ParseExact(dateString, "MMM d, yyyy", null);
            DateTime today = DateTime.Now.Date;
            // Act
            DateTime yearsNewValue = today.AddYears(years);
            // Assert
            dateToCheck.Should().BeOnOrAfter(yearsNewValue);
        }

        // sortorder can be asc / desc
        public static bool IsSortedDates(List<string> dateStrings, string sortOrder)
        {
            List<DateTime> dates = new();

            foreach (string dateString in dateStrings)
            {
                DateTime date;
                if (DateTime.TryParseExact(dateString, "MMM d, yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    dates.Add(date);
                }
            }

            if (sortOrder == "desc")
            {
                for (int i = 1; i < dates.Count; i++)
                {

                    if (dates[i] > dates[i - 1])
                    {
                        Console.WriteLine($"Dates causing failure in DESC sort order: {dates[i]} & {dates[i - 1]}");
                        return false;
                    }
                }
            }
            else if (sortOrder == "asc")
            {
                for (int i = 1; i < dates.Count; i++)
                {
                    if (dates[i] < dates[i - 1])
                    {
                        Console.WriteLine($"Dates causing failure in ASC sort order: {dates[i]} & {dates[i - 1]}");
                        return false;
                    }
                }
            }


            return true;
        }

        //this method checks if the given date is in between two dates or not 
        public static bool IsBetweenTwoDates(this DateOnly dt, DateOnly FromDate, DateOnly ToDate)
        {
            return dt >= FromDate && dt <= ToDate;
        }
        // this method will convert date from string to Date format
        public static DateOnly StringToShortDate(string date)
        {
            return DateOnly.Parse(Convert.ToDateTime(date).ToShortDateString());
        }

        public static DateTime ConvertToEasternTime(DateTime date)
        {
            var timeUtc = date;// 
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
            Console.WriteLine("Current Eastern Standard Time is : " + easternTime);
            return easternTime;
        }

    }
}
