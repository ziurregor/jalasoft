namespace Jalasoft.DevBootcamp.Observer.Pattern
{
    using System.Collections.Generic;

    public class Account
    {
        private int balance;

        private List<Person> persons;

        public Account()
        {
            this.persons = new List<Person>();
        }

        public void RegisterClient(Person person)
        {
            this.persons.Add(person);
        }

        public void Deposit(int amount)
        {
            this.balance = this.balance + amount;
            this.Inform();
        }

        public int GetAccountBalance()
        {
            return this.balance;
        }

        private void Inform()
        {
            foreach (var person in this.persons)
            {
                person.CurrentBalance();
            }
        }
    }
}
