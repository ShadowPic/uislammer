using Microsoft.Data.SqlClient;
using playwrightBDD.Setup;

namespace playwright.Helpers
{
    public class SqlDataHelper
    {

        public static List<Dictionary<string, object>> ExecuteQuery(string query)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            List<Dictionary<string, object>> resultData = new();
            // pull the values from appsettings file 
            builder.DataSource = CommonUtility.GetAValueFromAppSettings("SqlDataBase:DataSource");
            builder.UserID = CommonUtility.GetAValueFromAppSettings("SqlDataBase:UserID");
            builder.Password = CommonUtility.GetAValueFromAppSettings("SqlDataBase:Password");
            builder.InitialCatalog = CommonUtility.GetAValueFromAppSettings("SqlDataBase:InitialCatalog");
            builder.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                String sqlQuery = query;
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        string[] columnNames = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            columnNames[i] = reader.GetName(i);
                        }
                        while (reader.Read())
                        {
                            Dictionary<string, object> row = new Dictionary<string, object>();
                            for (int i = 0; i < columnNames.Length; i++)
                            {
                                string columnName = columnNames[i];
                                object value = reader.GetValue(i);
                                row[columnName] = value;
                            }
                            resultData.Add(row);
                        }
                    }
                }

            }
            return resultData;
        }

        public void ExampleSQLTest()
        {
            String sqlQuery = "SELECT TOP (10) * FROM [dbo].[Account]";
            var queryResults = ExecuteQuery(sqlQuery);
        }
    }
}
