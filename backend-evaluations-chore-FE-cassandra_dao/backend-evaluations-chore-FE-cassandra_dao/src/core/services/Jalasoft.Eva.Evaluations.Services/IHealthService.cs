namespace Jalasoft.Eva.Evaluations.Services
{
    using Jalasoft.Eva.Evaluations.Domain;

    public interface IHealthService
    {
        ApplicationHealthInfo GetServiceHealth();
    }
}
