using System;
namespace EventsDelegates
{
        public class SubscriberConsole
        {
            public void Subscribe(ref EvenDelegate evenDelegate)
            {
                if (evenDelegate == null)
                {
                    evenDelegate = WriteToConsole;
                }
                else
                {
                    evenDelegate += WriteToConsole;
                }
            }
            public void WriteToConsole(int number)
            {
                Console.WriteLine("The number is - {0}", number);
            }
        }

}
