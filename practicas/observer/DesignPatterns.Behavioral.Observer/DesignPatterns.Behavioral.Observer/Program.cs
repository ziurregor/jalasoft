using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();

            new ViewOne(subject);
            new ViewTwo(subject);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Changing subject state to: {i}");
                subject.SetState(i);
            }
        }
    }
}
