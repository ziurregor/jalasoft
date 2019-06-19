using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    class Axe : Weapons
    {
        public Axe(Armor armor) : base(armor)
        {
            description = "Axe";
        }
        public override int strength
        {
            get
            {
                return 2 + Armor.strength;
            }
            set
            {

            }
        }
        public override int agility
        {
            get
            {
                return 0 + Armor.agility;
            }
            set
            {

            }

        }
        public override int precision
        {
            get
            {
                return 0 + Armor.precision;
            }
            set
            {

            }
        }
        public override string GetHabilities()
        {
            return Armor.GetHabilities() + " + BowArrow";
        }
    }
}
