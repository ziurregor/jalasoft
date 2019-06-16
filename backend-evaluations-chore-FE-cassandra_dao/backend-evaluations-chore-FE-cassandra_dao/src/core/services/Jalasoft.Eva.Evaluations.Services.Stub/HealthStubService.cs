namespace Jalasoft.Eva.Evaluations.Services.Stub
{
    using System;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Services;

    internal class HealthStubService
        : IHealthService, IRegistrableFactory<IHealthService>
    {
        public IHealthService CreateInstance()
        {
            return new HealthStubService();
        }

        public ApplicationHealthInfo GetServiceHealth()
        {
            var appInfo = new ApplicationInfo()
            {
                Name = "EvaluationService",
                Version = "0.9",
                Id = Guid.NewGuid()
            };

            return new ApplicationHealthInfo()
            {
                Application = appInfo,
                Status = ApplicationHealthStatus.Up
            };
        }
    }
}
