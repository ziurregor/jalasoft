namespace Jalasoft.DevBootcamp.Observer.Client
{
    using System;
    using Jalasoft.DevBootcamp.Observer.Pattern;
    using Jalasoft.DevBootcamp.Observer.Viewers;

    public class Program
    {
        public static void Main(string[] args)
        {
            var account = new Account();
            new Husband(account);
            new Wife(account);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Changing account balance state to: {i}");
                account.Deposit(2088)
;            }
        }
    }
}
