using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    class DwarfArmor : Armor
    {
        public DwarfArmor()
        {
            description = "DwarfArmor";
        }

        public override int strength {
            get
            {
                return 10;
            }
            set
            {
                
            }

        }

       

        public override int agility {
            get
            {
                return 4;
            }
            set
            {

            }
        }

       

        public override int precision {
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
