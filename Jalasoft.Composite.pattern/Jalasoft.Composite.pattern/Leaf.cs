using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.Composite.pattern
{
    public class Leaf : Obj
    {
        public Leaf(string name, int price):base(name,price)
        {

        }
        public override int calcPrice()
        {
            Console.WriteLine($"{name} with price {price}");
            return price;
        }
    }
}
