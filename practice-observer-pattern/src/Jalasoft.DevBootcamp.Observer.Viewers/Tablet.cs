namespace Jalasoft.DevBootcamp.Observer.Viewers
{
    using System;
    using Jalasoft.DevBootcamp.Observer.Pattern;

    public class Tablet : Device
    {
        public Tablet(Account account, string name) : base(account)
        {
            this.Name = name;
        }

        public override void CurrentBalance()
        {
            var balance = Savings.GetAccountBalance();
            Console.WriteLine($"Savings account balance: [{balance}] and received by tablet [{this.Name}].");
        }
    }
}
