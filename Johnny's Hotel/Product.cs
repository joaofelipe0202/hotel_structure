namespace Lab1_OOP
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Code { get; set; }
        public Product(string name, int price, string code)
        {
            if(price < 0 || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code))
            {
                throw new NegativePriceException("You entered a negative price/no name/empty code for product");
            }
            this.Name = name;
            this.Price = price;
            this.Code = code;
        }
    }
}
