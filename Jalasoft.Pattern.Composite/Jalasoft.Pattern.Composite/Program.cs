using System;

namespace Jalasoft.Pattern.Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
                var phone = new Product("Phone", 100);
                phone.CalculateTotalPrice();
                Console.WriteLine();

                //composite gift
                var rootBox = new BoxOfGift("RootBox", 10);

                var truckToy = new Product("TruckToy", 200);
                var plainToy = new Product("PlainToy", 300);
                rootBox.Add(truckToy);
                rootBox.Add(plainToy);
                var childBox = new BoxOfGift("ChildBox", 90);
                var soldierToy = new Product("SoldierToy", 200);
                childBox.Add(soldierToy);
                rootBox.Add(childBox);

                Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
            
        }
    }
}
