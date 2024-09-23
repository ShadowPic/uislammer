
namespace playwrightSolution.Helpers
{
    internal static class FileOps
    {

        public static void createfile(string filePath, string valueToWrite)
        {
            try
            {
                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new(filePath))
                {
                    // Write the value to the file
                    writer.WriteLine(valueToWrite);
                }

                Console.WriteLine("File created and value written successfully. -->" + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static string? readfile(string filePath)
        {
            // Define the file path
            string valueRead = null!;
            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new(filePath))
                    {
                        // Read the value from the file
                        valueRead = reader.ReadLine()!;

                        // Display the value on the console
                        //Console.WriteLine("Value read from the file: " + valueRead);
                    }
                }
                else
                {
                    Console.WriteLine("The file does not exist. --> " + filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return valueRead;
        }

        public static void deleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine(filePath + " deleted successfully.");
            }
            else
            {
                Console.WriteLine(filePath + " does not exist.");
            }
        }
    }

}

