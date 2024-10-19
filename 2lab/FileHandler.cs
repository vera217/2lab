using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public class FileHandler
    {

        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static List<object> ParseData(string data)
        {
            var objects = new List<object>();
            foreach (var entry in data.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (entry.StartsWith("Поступление товаров:")) objects.Add(ParseProduct(entry));
                else if (entry.StartsWith("Поставщик:")) objects.Add(ParseSupplier(entry));
                else if (entry.StartsWith("Акт возврата:")) objects.Add(ParseReturnAct(entry));
            }
            return objects;
        }

        private static Product ParseProduct(string entry)
        {
            var parts = entry.Split(';');
            return new Product(
                DateTime.ParseExact(parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(), "yyyy.MM.dd", null),
                parts[1].Trim(' ', '\''),
                int.Parse(parts[2].Trim())
            );
        }

        private static Supplier ParseSupplier(string entry)
        {
            var parts = entry.Split(';');
            return new Supplier(
                parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(),
                parts[1].Trim(),
                parts[2].Trim()
            );
        }

        private static ReturnAct ParseReturnAct(string entry)
        {
            var parts = entry.Split(';');
            return new ReturnAct(
                DateTime.ParseExact(parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(), "yyyy.MM.dd", null),
                parts[1].Trim(' ', '\''),
                int.Parse(parts[2].Trim()),
                parts[3].Trim()
            );
        }
    }
}
