using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.Composite.pattern
{
    interface IObject
    {
        void Add(Obj obj);
        void Remove(Obj obj);
    }
}
