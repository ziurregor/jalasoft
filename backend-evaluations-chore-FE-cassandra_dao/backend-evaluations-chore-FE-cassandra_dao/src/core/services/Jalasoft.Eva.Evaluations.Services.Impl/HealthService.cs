namespace Jalasoft.Eva.Evaluations.Services.Impl
{
    using System;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Dao;
    using Jalasoft.Eva.Evaluations.Dao.Fs;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Services;

    public sealed class HealthService : AbstractService, IHealthService, IRegistrableFactory<IHealthService>
    {
        private static readonly string ApplicationInfoFile = $"{AppDomain.CurrentDomain.BaseDirectory}/ApplicationInfo.json";
        private IFileDaoBuilder<IAppInfoDao> appInfoDaoBuilder;

        public HealthService()
            : base()
        {
        }

        public HealthService(IFileDaoBuilder<IAppInfoDao> appInfoDaoBuilder)
        {
            this.appInfoDaoBuilder = appInfoDaoBuilder;
        }

        public IHealthService CreateInstance()
        {
            var daoBuilder = new AppInfoDao();
            return new HealthService(daoBuilder);
        }

        public ApplicationHealthInfo GetServiceHealth()
        {
            return ServiceErrorHandler.Handle(() =>
            {
                Log.Info("Getting the application health information");
                var dao = this.appInfoDaoBuilder.CreateFromFile(ApplicationInfoFile);
                var appInfo = dao.GetAppInfo();

                var info = new ApplicationHealthInfo()
                {
                    Application = appInfo,
                    Status = ApplicationHealthStatus.Up
                };

                Log.Info(string.Format("ApplicationHealthInfo: {0}", info));
                return info;
            });
        }
    }
}