using System.Globalization;
using System;
using _2lab;

class Program
{
    static void Main(string[] args)
    {
        string s = "Поступление товаров: 2023.01.05; 'яблоки'; 20 ;";
        Console.WriteLine(s);

        if (!s.StartsWith("Поступление товаров:"))
        {
            Console.WriteLine("Некорректный ввод: строка должна начинаться с Поступление товаров:");
            return;
        }

        s = s.Substring(s.IndexOf(":") + 1).Trim();

        string[] words = s.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);


        if (words.Length < 3)
        {
            Console.WriteLine("Некорректные данные: недостаточно элементов.");
            return;
        }

        if (!DateTime.TryParseExact(words[0].Trim(), "yyyy.MM.dd", null, DateTimeStyles.None, out DateTime parsedDate))
        {
            Console.WriteLine("Неверный ввод даты");
            return;
        }

        string productName = words[1].Trim(' ', '\'');


        if (int.TryParse(words[2].Trim(), out int quantity))
        {
            Product product = new Product(parsedDate, productName, quantity);
            Console.WriteLine(product.PrintInfo());
        }
        else
        {
            Console.WriteLine("Некорректные данные");
        }
    }
}
