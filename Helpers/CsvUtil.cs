using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Globalization;

namespace playwrightSolution.Helpers
{
    public class CsvUtil
    {

        public async Task<string[]> getDateDataFromResponse(string responseCSV)
        {
            string[] dateArray;
            using (var reader = new StringReader(responseCSV))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true }))
            {
                var records = csv.GetRecords<dynamic>().ToList();
                dateArray = records.Select(record => (string)record.Date).ToArray();
            }

            return dateArray;
        }
    }
}
