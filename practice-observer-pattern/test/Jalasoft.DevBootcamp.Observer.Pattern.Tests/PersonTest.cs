using System;
using Jalasoft.DevBootcamp.Observer.Pattern;
using Xunit;

namespace TestPerson
{
    public class PersonTest : Person
    {

        public PersonTest(Account account) : base(account)
        {

        }

        [Fact]
        public override void CurrentBalance()
        {
            var balance = Savings.GetAccountBalance();
            Assert.IsType<Int32>(balance);
        }


    }
}

