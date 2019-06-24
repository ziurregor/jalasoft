using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.Composite.pattern
{
    public class Composite : Obj, IObject
    {
        private List<Obj> _obj;
        public Composite(string name, int price) : base(name, price)
        {
            _obj = new List<Obj>();
           
        }

        public override int calcPrice()
        {
            int tt=0;
            Console.WriteLine($" {name} contains the following products");
            foreach (var objs in _obj)
            {
                tt = tt + objs.calcPrice();
            }
            return tt + this.price;
        }

        public void Add(Obj obj)
        {
            //throw new NotImplementedException();
            _obj.Add(obj);
        }


        public void Remove(Obj obj)
        {
            throw new NotImplementedException();
        }
    }
}
