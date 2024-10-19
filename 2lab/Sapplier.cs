using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public class Supplier
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }

        public Supplier(string name, string contactPerson, string phoneNumber)
        {
            Name = name;
            ContactPerson = contactPerson;
            PhoneNumber = phoneNumber;
        }

        public string PrintInfo() => $"Поставщик: {Name}\nКонтактное лицо: {ContactPerson}\nТелефон: {PhoneNumber}\n";
    }
}
