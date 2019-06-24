using System;

namespace Jalasoft.Composite.pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var phone = new Leaf("Phone", 256);
            phone.calcPrice();
            Console.WriteLine();
            //composite gift
            var rootBox = new Composite("RootBox", 1000);
            var truckToy = new Leaf("TruckToy", 289);
            var plainToy = new Leaf("PlainToy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
          
            var childBox = new Composite("ChildBox", 4);
            var soldierToy = new Leaf("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"tt price of composite  is {rootBox.calcPrice()}");
        }
    }
}

