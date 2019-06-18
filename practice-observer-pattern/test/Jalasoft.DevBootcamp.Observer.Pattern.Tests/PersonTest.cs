using System;
using Jalasoft.DevBootcamp.Observer.Pattern;
using Jalasoft.DevBootcamp.Observer.Viewers;
using Xunit;

namespace TestPerson
{
    public class PersonTest
    {

        [Fact]
        public  void TestCurrentBalance()
        {
            var account = new Account();

            account.Deposit(2088);
            Console.WriteLine(account.GetAccountBalance());

            Assert.Equal(2088, account.GetAccountBalance());

        }


    }
}

