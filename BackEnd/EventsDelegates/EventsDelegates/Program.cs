using System;

namespace EventsDelegates
{
    class Program
    {
        public static void Main(string[] args)
        {
            var publisher = new Publisher();
            var subscriberConsole = new SubscriberConsole();
            var subscriberFile = new SubscriberFile();
            subscriberConsole.Subscribe(ref publisher.EvenDelegate);
            subscriberFile.Subscribe(ref publisher.EvenDelegate);
            publisher.Publish();
        }
    }
}
