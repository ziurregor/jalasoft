namespace Jalasoft.DevBootcamp.Observer.Pattern
{
    public abstract class Person
    {
        public Person(Account account)
        {
            this.Savings = account;
            this.Savings.RegisterClient(this);
        }

        public Account Savings { get; set; }

        public abstract void CurrentBalance();
    }
}
