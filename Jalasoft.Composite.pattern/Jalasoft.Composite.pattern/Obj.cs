using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.Composite.pattern
{
    public abstract class Obj
    {
        protected string name;
        protected int price;
        public Obj(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int calcPrice();
    }
}
