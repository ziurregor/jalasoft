using System;

namespace Jalasoft.Pattern.Composite
{
    public class Product : ProductBase
    {
        public Product(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");

            return price;
        }
    }
}