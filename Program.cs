

using System.Text.RegularExpressions;

namespace SeeFood
{
    internal class Program
    {
        private static string CognitiveEndpoint = "https://compvisionseefood.cognitiveservices.azure.com/";
        private static string CognitiveKey = "16fea0ae9134441baf586041c8125192";

        static void Main(string[] args)
        {
            ImageAnalyzer imageAnalyzer = new();

            string input = "";

            
            while (input.ToLower() != "quit")
            {
                
                Console.Write("Insert Image URL: ");
                input = Console.ReadLine();

                if (input == "quit") return;

                if(IsValidUrl(input))
                {
                    imageAnalyzer.DectectItemsAsync(input);
                    Console.ReadKey();
                    Console.Clear();
                }              
                else
                {
                    Console.WriteLine("Invalid URL. Please enter a valid URL.");
                }                
            }

            static bool IsValidUrl(string url)
            {
                // Define a regular expression pattern for a valid URL
                string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";

                // Use Regex.IsMatch to check if the input matches the pattern
                return Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase);
            }

        }
    }
}