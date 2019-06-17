namespace Jalasoft.DevBootcamp.Observer.Pattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Account
    {
        private int balance;

        private List<Device> mobiles;

        public Account()
        {
            this.mobiles = new List<Device>();
        }

        public void RegisterDevice(Device device)
        {
            this.mobiles.Add(device);
        }

        public int CountMobiles()
        {
            return this.mobiles.Count();
        }

        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                this.balance = this.balance + amount;
                this.Inform();
            }
            else
            {
                Console.WriteLine($"The amount [{amount}] should be major to 0.");
            }
        }

        public void UnregsiterMobile(Device mobile)
        {
            this.mobiles.Remove(mobile);
        }

        public Device GetMobile(string name)
        {
            return this.mobiles.FirstOrDefault(p => p.Name == name);
        }

        public int GetAccountBalance()
        {
            return this.balance;
        }

        private void Inform()
        {
            foreach (var person in this.mobiles)
            {
                person.CurrentBalance();
            }
        }
    }
}
