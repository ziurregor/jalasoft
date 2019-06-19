using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    class ElfArmor : Armor
    {
        public ElfArmor()
        {
            description = "DwarfArmor";
        }

        public override int strength
        {
            get
            {
                return 4;
            }
            set
            {

            }

        }



        public override int agility
        {
            get
            {
                return 10;
            }
            set
            {

            }
        }



        public override int precision
        {
            get
            {
                return 5;
            }
            set
            {

            }
        }
    }
}
