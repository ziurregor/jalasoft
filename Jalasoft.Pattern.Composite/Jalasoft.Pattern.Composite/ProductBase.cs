using System;
namespace Jalasoft.Pattern.Composite
{
    public abstract class ProductBase
    {
        protected string name;
        protected int price;

        public ProductBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int CalculateTotalPrice();
    }
}
