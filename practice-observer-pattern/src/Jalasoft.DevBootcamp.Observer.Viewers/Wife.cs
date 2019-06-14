namespace Jalasoft.DevBootcamp.Observer.Viewers
{
    using System;
    using Jalasoft.DevBootcamp.Observer.Pattern;

    public class Wife : Person
    {
        public Wife(Account account) : base(account)
        {
        }

        public override void CurrentBalance()
        {
            var balance = Savings.GetAccountBalance();
            Console.WriteLine($"Savings account balance: [{balance}] and received by Wife.");
        }
    }
}
