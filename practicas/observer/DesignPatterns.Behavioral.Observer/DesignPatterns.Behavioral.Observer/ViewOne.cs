﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    class ViewOne : Observer
    {
        public ViewOne(Subject subject) : base(subject)
        {
        }

        public override void Update()
        {
            var state = subject.GetState();
            Console.WriteLine($"State changed to: [{state}] and received by ViewOne.");
        }
    }
}
