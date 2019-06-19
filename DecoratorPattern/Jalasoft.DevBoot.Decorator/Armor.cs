using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.DevBoot.Decorator
{
    abstract class Armor
    {
        protected string description = "armor name";

        protected Armor()
        {
        }

        public virtual string GetHabilities()
        {
            return this.description;
        }

        public abstract int strength { get; set; }
        public abstract int agility { get; set; }
        public abstract int precision { get; set; }

    }
}
