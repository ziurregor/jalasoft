namespace Jalasoft.Eva.Evaluations.Services.Impl
{
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;

    public abstract class AbstractService
    {
        protected static readonly ILogger Log = LoggerFactory.GetLogger(typeof(HealthService));
        protected static readonly ServicesExceptionHandler ServiceErrorHandler = new ServicesExceptionHandler();

        public AbstractService()
        {
        }
    }
}
