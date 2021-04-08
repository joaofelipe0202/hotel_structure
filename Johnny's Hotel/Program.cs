using System;
using System.Collections.Generic;

namespace Lab1_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Product coke = new Product("coke", 1, "A1");
            Product doritos = new Product("doritos", 3, "A3");
            Dictionary<int, int> moneyFloat = new Dictionary<int, int> { { 20, 4 }, { 10, 2 }, { 5, 1 }, { 2, 2 }, { 1, 10 } };
            Dictionary<Product, int> inventory = new Dictionary<Product, int>();
           
            VendingMachine machine = new VendingMachine(moneyFloat, inventory, "jjjkkk");

            machine.StockItem(coke, 3);
            machine.StockItem(doritos, 2);
            List<int> moneyIn = new List<int> { 1, 2, 5 };
            Console.WriteLine(machine.VendItems("A3", moneyIn));

        }
        static void PrintDictionary(Dictionary<Product, int> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
    }
}
