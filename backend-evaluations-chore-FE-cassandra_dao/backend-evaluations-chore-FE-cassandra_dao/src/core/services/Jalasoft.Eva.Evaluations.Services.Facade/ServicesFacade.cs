namespace Jalasoft.Eva.Evaluations.Services.Facade
{
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Services;

    public class ServicesFacade
    {
        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(ServicesFacade));
        private static object lockObj = new object();
        private static volatile ServicesFacade instance;
        private Configurator configurator;

        private ServicesFacade()
        {
            this.configurator = new Configurator();
        }

        public static ServicesFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new ServicesFacade();
                        }
                    }
                }

                return instance;
            }
        }

        public void RegisterHealthService(string assemblyPath)
        {
            Log.Info(string.Format("Registering the HealthService from {0}", assemblyPath));
            this.configurator.RegisterFactory<IHealthService>(assemblyPath);
        }

        public IHealthService GetHealthService()
        {
            Log.Info("Getting the registered HealthService");
            return this.configurator.GetInstance<IHealthService>();
        }

        public void RegisterEvaluationsService(string assemblyPath)
        {
            Log.Info(string.Format("Registering the EvaluationService from {0}", assemblyPath));
            this.configurator.RegisterFactory<IEvaluationsService>(assemblyPath);
        }

        public IEvaluationsService GetEvaluationsService()
        {
            Log.Info("Getting the registered EvaluationService");
            return this.configurator.GetInstance<IEvaluationsService>();
        }

        public void RegisterTemplatesService(string assemblyPath)
        {
            Log.Info(string.Format("Registering the TemplatesService from {0}", assemblyPath));
            this.configurator.RegisterFactory<ITemplatesService>(assemblyPath);
        }

        public ITemplatesService GetTemplatesService()
        {
            Log.Info("Getting the registered TemplatesService");
            return this.configurator.GetInstance<ITemplatesService>();
        }

        public void RegisterAnswersService(string assemblyPath)
        {
            Log.Info(string.Format("Registering the AnswersService from {0}", assemblyPath));
            this.configurator.RegisterFactory<IAnswersService>(assemblyPath);
        }

        public IAnswersService GetAnswersService()
        {
            Log.Info("Getting the registered AnswersService");
            return this.configurator.GetInstance<IAnswersService>();
        }

        public void RegisterScoreService(string assemblyPath)
        {
            Log.Info(string.Format("Registering the ScoreService from {0}", assemblyPath));
            this.configurator.RegisterFactory<IScoreService>(assemblyPath);
        }

        public IScoreService GetScoreService()
        {
            Log.Info("Getting the registerd ScoreService");
            return this.configurator.GetInstance<IScoreService>();
        }
    }
}