using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace JSONParser
{
    class Program
    {
        static bool isWhatIWant(char c) {
            return Char.IsLetterOrDigit(c)
                || Char.IsWhiteSpace(c)
                || Char.IsSeparator(c)
                || Char.IsPunctuation(c);
        }
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"\Report\DataModelSchema.txt");
            string builder = @"";
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\kryan\Source\Repos\JSONParser\JSONParser\JSONParser\Report\DataModelSchema.txt"))
                {
                    while (sr.Peek() >= 0) {
                        builder += sr.ReadLine();
                    }

                }

            }
            catch (Exception e) { }
            string test = "";
            foreach (char c in builder) {
                if (isWhatIWant(c)) {
                    test += c;
                }
            }

            Newtonsoft.Json.Linq.JObject json = Newtonsoft.Json.Linq.JObject.Parse(test);
            JsonReader reader = json.CreateReader();

            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                }
            }

            Console.ReadLine();
        }
    }
}
