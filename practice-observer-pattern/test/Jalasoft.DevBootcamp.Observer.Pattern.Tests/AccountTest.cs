namespace Jalasoft.DevBootcamp.Observer.Pattern.Tests
{
    using Jalasoft.DevBootcamp.Observer.Pattern;
    using Jalasoft.DevBootcamp.Observer.Viewers;
    using Xunit;

    public class AccountTest
    {
        [Fact]
        public void Unregister_Account_UnregisteredMobile()
        {
            var account = new Account();
            var registeredMobiles = account.CountDevices();

            var iphoneMobile = new Mobile(account, "iphone");
            Assert.Equal(registeredMobiles + 1, account.CountDevices());

            account.UnregsiterDevice(iphoneMobile);
            Assert.Equal(registeredMobiles, account.CountDevices());
        }
    }
}
