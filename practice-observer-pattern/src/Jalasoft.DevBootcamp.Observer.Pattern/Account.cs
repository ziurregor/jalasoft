namespace Jalasoft.DevBootcamp.Observer.Pattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Account
    {
        private int balance;

        private List<Device> devices;

        public Account()
        {
            this.devices = new List<Device>();
        }

        public void RegisterDevice(Device device)
        {
            this.devices.Add(device);
        }

        public int CountDevices()
        {
            return this.devices.Count();
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

        public void UnregsiterDevice(Device device)
        {
            bool removed = this.devices.Remove(device);
            if (removed)
            {
                Console.WriteLine($"Device: [{device.Name}], type: [{device.GetType().Name}] unregistered sucessfully!");
            }
        }

        public Device GetDevice(string name)
        {
            return this.devices.FirstOrDefault(p => p.Name == name);
        }

        public int GetAccountBalance()
        {
            return this.balance;
        }

        private void Inform()
        {
            foreach (var person in this.devices)
            {
                person.CurrentBalance();
            }
        }

        public void ListDevices()
        {
            foreach (var device in this.devices)
            {
                Console.WriteLine($"Device's name: [{device.Name}], Device's type: [{device.GetType().Name}]");
            }
        }
    }
}
