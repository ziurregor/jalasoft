using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    abstract class Observer
    {
        protected Subject subject;

        public Observer(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public abstract void Update();
    }
}
