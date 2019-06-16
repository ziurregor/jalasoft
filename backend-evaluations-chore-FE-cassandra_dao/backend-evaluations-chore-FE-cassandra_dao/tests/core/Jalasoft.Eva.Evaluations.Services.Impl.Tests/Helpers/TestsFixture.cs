namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests.Helpers
{
    using System.Configuration;
    using System.Reflection;
    using Jalasoft.Eva.Evaluations.Services.Facade;

    public class TestsFixture
    {
        public TestsFixture()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            var servicesDll = ConfigurationManager.OpenExeConfiguration(path).AppSettings.Settings["servicesDll"].Value;
            ServicesFacade.Instance.RegisterTemplatesService(servicesDll);
        }
    }
}