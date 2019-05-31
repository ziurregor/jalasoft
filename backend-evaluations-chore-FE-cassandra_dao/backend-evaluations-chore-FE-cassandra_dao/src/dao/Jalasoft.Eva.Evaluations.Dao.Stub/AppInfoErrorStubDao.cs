namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain;

    public class AppInfoErrorStubDao : IAppInfoDao, IFileDaoBuilder<IAppInfoDao>
    {
        public IAppInfoDao CreateFromFile(string fileName)
        {
            return new AppInfoErrorStubDao();
        }

        public ApplicationInfo GetAppInfo()
        {
            throw new InternalErrorDaoException("The file does not exist");
        }
    }
}