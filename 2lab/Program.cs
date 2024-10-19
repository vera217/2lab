using System.Globalization;
using System;
using _2lab;

class Program
{
    static void Main(string[] args)
    {
        
        string fileData = FileHandler.ReadFile("file.txt");
        List<object> fileObjects = FileHandler.ParseData(fileData);
        PrintObjects(fileObjects);

        
        Console.WriteLine("Вывод из строки \n");
        string stringData = "Поступление товаров: 2023.01.05; 'яблоки'; 20;\n" +
            "Поставщик: ООО 'Фрукты'; Петр Иванов; +79991234567\n" +
            "Акт возврата: 2020.03.01; 'яблоки'; 5; Некачественный товар\n ";
        List<object> stringObjects = ParseData(stringData);
        PrintObjects(stringObjects);
    }

    static List<object> ParseData(string data)
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

    static Product ParseProduct(string entry)
    {
        var parts = entry.Split(';');
        return new Product(
            DateTime.ParseExact(parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(), "yyyy.MM.dd", null),
            parts[1].Trim(' ', '\''),
            int.Parse(parts[2].Trim())
        );
    }

    static Supplier ParseSupplier(string entry)
    {
        var parts = entry.Split(';');
        return new Supplier(
            parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(),
            parts[1].Trim(),
            parts[2].Trim()
        );
    }

    static ReturnAct ParseReturnAct(string entry)
    {
        var parts = entry.Split(';');
        return new ReturnAct(
            DateTime.ParseExact(parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(), "yyyy.MM.dd", null),
            parts[1].Trim(' ', '\''),
            int.Parse(parts[2].Trim()),
            parts[3].Trim()
        );
    }

    static void PrintObjects(List<object> objects)
    {
        foreach (var obj in objects)
        {
            if (obj is Product product) Console.WriteLine(product.PrintInfo());
            else if (obj is Supplier supplier) Console.WriteLine(supplier.PrintInfo());
            else if (obj is ReturnAct returnAct) Console.WriteLine(returnAct.PrintInfo());
        }
    }
}

