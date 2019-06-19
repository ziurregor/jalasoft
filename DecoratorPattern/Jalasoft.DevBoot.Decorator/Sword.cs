using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    class Sword : Weapons
    { 
        public Sword(Armor armor) : base(armor)
        {
            description = "Sword";
        }
        public override int strength {
            get
            {
                return 0 + Armor.strength;
            }
            set
            {

            }
        }
        public override int agility {
            get
            {
                return 0 + Armor.agility;
            }
            set
            {

            }

        }
        public override int precision {
            get
            {
                return 2 + Armor.precision;
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
