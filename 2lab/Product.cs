using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public class Product
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(DateTime date, string name, int quantity)
        {
            Date = date;
            Name = name;
            Quantity = quantity;

        }

        public virtual string PrintInfo()
        {
            return $"Дата: {Date.ToShortDateString()} \nНазвание: {Name} \nКоличество: {Quantity}";
        }
    }
}
