using System;
using System.Collections.Generic;

namespace Jalasoft.Pattern.Composite
{
    public class BoxOfGift : ProductBase, IProductOperations
    {
        private List<ProductBase> _gifts;

        public BoxOfGift(string name, int price)
            : base(name, price)
        {
            _gifts = new List<ProductBase>();
        }

        public void Add(ProductBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(ProductBase gift)
        {
            _gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} with price {price}, contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                total += gift.CalculateTotalPrice() ;
            }

            return total + price;
        }
    }
}
