using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_OOP
{
    public class VendingMachine
    {
        public static int SERIALNUMBER = 0; 
        public Dictionary<int, int>MoneyFloat { get; set; }
        public Dictionary<Product, int>Inventory { get; set; }

        public readonly string Barcode;
        public VendingMachine(Dictionary<int, int> moneyFloat, Dictionary<Product, int> inventory, string barcode)
        {   
            this.MoneyFloat = moneyFloat;
            this.Inventory = inventory;
            SERIALNUMBER++;
            this.Barcode = barcode;
        }
        public string StockItem(Product product, int quantity)
        {
            quantity = 1;

            foreach(var item in Inventory)
            {
                try
                {
                    if (!Inventory.ContainsKey(product))
                    {
                        Inventory.Add(product, quantity);
                    }
                    else
                    {
                        quantity++;
                        Inventory[product] = quantity;
                    }
                }
                catch(NegativePriceException e)
                {
                    Console.WriteLine(e);
                }
            }
            string confirmation = "Product " + product.Name + " with code $" + product.Code + ", and price " + product.Price + ", has been added to the inventory";

            return confirmation;
        }
        public string StockFloat(int moneyDemonition, int quantity)
        {
            quantity = 1;
            foreach(var money in MoneyFloat)
            {
                if(!MoneyFloat.ContainsKey(moneyDemonition))
                {
                    MoneyFloat.Add(moneyDemonition, quantity);
                }
                else
                {
                    quantity++;
                    MoneyFloat[moneyDemonition] = quantity;
                }
            }
            string confirmation = quantity + "$" + moneyDemonition + "coins to the machine’s change float.";

            return confirmation;
        }
        public string VendItems(string code, List<int> money)
        {
            string output = "";
            int moneyIn = TotalMoneyInsertedByTheUser(money);
            Product currentItem = SearchProductByItCode(code);
            int change = moneyIn - currentItem.Price;

            if (string.IsNullOrEmpty(code))
                throw new NegativePriceException("Please, enter a proper code. Please, choose another product.");

            else if (Inventory[currentItem] <= 0)
                throw new NoProductInStockException("Sorry, product out of stock.");
            else if (change < 0)
                throw new LessQuantityException("The amount of money entered is not sufficient. Please, enter more money.");

            else if (moneyIn > VendingMachineTotalCash())
                throw new LessQuantityException($"The machine has not enough money, take your refund ${moneyIn}.");

            else if (moneyIn < VendingMachineTotalCash())
            {
                if (moneyIn == currentItem.Price)
                    output += "Enjoy your " + currentItem.Name + ".No change required.";
                else
                {
                    Inventory[currentItem]--;
                    DecreaseMoneyFloat(MoneyFloat, change);
                    IncreaseMoneyFloat(MoneyFloat, moneyIn);
                    output += "Please enjoy your " + currentItem.Name + " and take your change of $" + change;
                }
            }
            return output;
        }
        public int TotalMoneyInsertedByTheUser(List<int> money)
        {
            int total = 0;
            for(int i = 0; i < money.Count; i++)
            {
                total += money[i];
            }
            return total;
        }
        public Product SearchProductByItCode(string code)
        {
            foreach(var product in Inventory)
            {
                if (code == product.Key.Code)
                {
                    return product.Key;
                }   
            }
            return new Product("", 0, "");
        }
        public int VendingMachineTotalCash()
        {
            int total = 0;
            foreach(var money in MoneyFloat)
            {
                total = money.Key * money.Value;
            }
            return total;
        }
        public void DecreaseMoneyFloat(Dictionary<int,int> MoneyFloat, int money)
        {
            if (MoneyFloat[money] > 0)
                MoneyFloat[money]--;
        }
        public void IncreaseMoneyFloat(Dictionary<int,int> MoneyFloat, int money)
        {
            if (MoneyFloat.ContainsKey(money))
            {
                MoneyFloat[money]++;
            }
        }
    }
}
