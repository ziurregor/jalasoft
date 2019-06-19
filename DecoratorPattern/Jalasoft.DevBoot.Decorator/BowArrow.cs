using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    class BowArrow : Weapons
    {
        public BowArrow(Armor armor) : base(armor)
        {
            //description = "BowArrow";
        }
        public override int strength
        {
            get
            {
                return 0 + Armor.strength;
            }
            set
            {

            }
        }
        public override int agility
        {
            get
            {
                return 2 + Armor.agility;
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
