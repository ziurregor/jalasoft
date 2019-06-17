namespace Jalasoft.DevBootcamp.Observer.Viewers
{
    using System;
    using Jalasoft.DevBootcamp.Observer.Pattern;

    public class Mobile : Device
    {
        public Mobile(Account account, string name) : base(account)
        {
           this.Name = name;
        }

        public override void CurrentBalance()
        {
            var balance = Savings.GetAccountBalance();
            Console.WriteLine($"Savings account balance: [{balance}] and received by mobile [{this.Name}].");
        }
    }
}
