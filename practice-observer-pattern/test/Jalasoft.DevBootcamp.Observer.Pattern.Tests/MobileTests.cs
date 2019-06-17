namespace TestPerson
{
    using Jalasoft.DevBootcamp.Observer.Pattern;
    using Xunit;

    public class MobileTests
    {
        [Fact]
        public void Deposit_CurrentBalance_Deposit2088()
        {
            var account = new Account();
            account.Deposit(2088);

            Assert.Equal(2088, account.GetAccountBalance());
        }

        [Fact]
        public void Deposit_CurrentBalance_2Deposits3100()
        {
            var account = new Account();
            account.Deposit(1550);
            account.Deposit(1550);
            Assert.Equal(3100, account.GetAccountBalance());
        }

        [Fact]
        public void Deposit_CurrentBalance_NegativeDeposit()
        {
            var account = new Account();
            account.Deposit(2500);
            account.Deposit(-2500);
            Assert.Equal(2500, account.GetAccountBalance());
        }
    }
}