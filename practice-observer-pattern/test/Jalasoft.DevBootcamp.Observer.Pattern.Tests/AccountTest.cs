namespace Jalasoft.DevBootcamp.Observer.Pattern.Tests
{
    using Jalasoft.DevBootcamp.Observer.Pattern;
    using Jalasoft.DevBootcamp.Observer.Viewers;
    using Xunit;

    public class AccountTest
    {
        [Fact]
        public void Unregister_Account_UnregisteredHusbandMobile()
        {
            var account = new Account();
            var registeredMobiles = account.CountMobiles();

            var husbandMobile = new Mobile(account, "iphone");
            Assert.Equal(registeredMobiles + 1, account.CountMobiles());

            account.UnregsiterMobile(husbandMobile);
            Assert.Equal(registeredMobiles, account.CountMobiles());
        }
    }
}
