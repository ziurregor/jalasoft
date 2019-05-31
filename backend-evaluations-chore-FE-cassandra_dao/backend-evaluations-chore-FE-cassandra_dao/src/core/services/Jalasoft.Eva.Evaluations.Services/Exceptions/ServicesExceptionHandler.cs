namespace Jalasoft.Eva.Evaluations.Services.Exceptions
{
    using Jalasoft.Eva.Core.ExceptionHandler;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;

    public class ServicesExceptionHandler : AbstractExceptionHandler<ServiceException>
    {
        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(ServicesExceptionHandler));

        public ServicesExceptionHandler()
            : base()
        {
            this.Catch<InternalErrorDaoException>(ex =>
            {
                Log.Error($"{ex.Message}", ex);
                return new InternalErrorServiceException(ex.Message, ex);
            })
            .Catch<ItemNotFoundDaoException>(ex =>
            {
                Log.Info($"{ex.Message}");
                return new ItemNotFoundServiceException(ex.Message, ex);
            });
        }
    }
}
