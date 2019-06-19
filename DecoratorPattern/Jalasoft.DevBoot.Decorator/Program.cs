using System;

namespace Jalasoft.DevBoot.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Armor armor = new HumanArmor();

            Console.WriteLine($"{armor.GetHabilities()}, agility:{armor.agility}, precision:{armor.precision}, strength:{armor.strength}");

            armor = new BowArrow(armor);
            Console.WriteLine($"{armor.GetHabilities()}, agility:{armor.agility}, precision:{armor.precision}, strength:{armor.strength}");
            armor = new Axe(armor);
            Console.WriteLine($"{armor.GetHabilities()}, agility:{armor.agility}, precision:{armor.precision}, strength:{armor.strength}");
            armor = new Sword(armor);
            Console.WriteLine($"{armor.GetHabilities()}, agility:{armor.agility}, precision:{armor.precision}, strength:{armor.strength}");
            Console.ReadKey();


        }
    }
}
