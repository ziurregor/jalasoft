namespace Jalasoft.DevBootcamp.Observer.Pattern
{
    public abstract class Device
    {
        public Device(Account account)
        {
            this.Savings = account;
            this.Savings.RegisterDevice(this);
        }

        public string Name { get; set; }

        public Account Savings { get; set; }

        public abstract void CurrentBalance();
    }
}
