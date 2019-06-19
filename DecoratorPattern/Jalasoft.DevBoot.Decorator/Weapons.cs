using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    abstract class Weapons : Armor
    {
        public Weapons(Armor armor)
        {
            Armor = armor;
        }

        protected Armor Armor { get; set; }
    }
}
