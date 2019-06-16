namespace Jalasoft.Eva.Evaluations.Api.Rest.Tests.Helpers
{
    using System.Reflection;
    using Jalasoft.Eva.Evaluations.Services.Facade;

    public class ServicesRegistratorFixture
    {
        private static ServicesRegistratorFixture instance;
        private static object lockobject = new object();

        private ServicesRegistratorFixture()
        {
            var servicesDll = System.Configuration.ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["servicesDll"].Value;
            ServicesFacade.Instance.RegisterAnswersService(servicesDll);
            ServicesFacade.Instance.RegisterEvaluationsService(servicesDll);
            ServicesFacade.Instance.RegisterHealthService(servicesDll);
            ServicesFacade.Instance.RegisterTemplatesService(servicesDll);
        }

        public static ServicesRegistratorFixture Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (lockobject)
                {
                    if (instance == null)
                    {
                        instance = new ServicesRegistratorFixture();
                    }

                    return instance;
                }
            }
        }
    }
}
