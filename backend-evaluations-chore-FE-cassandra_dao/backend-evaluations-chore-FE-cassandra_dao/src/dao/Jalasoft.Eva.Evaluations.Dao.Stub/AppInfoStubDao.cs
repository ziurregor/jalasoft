namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using Jalasoft.Eva.Evaluations.Domain;

    public class AppInfoStubDao : IAppInfoDao, IFileDaoBuilder<IAppInfoDao>
    {
        public AppInfoStubDao()
        {
        }

        public IAppInfoDao CreateFromFile(string fileName)
        {
            return new AppInfoStubDao();
        }

        public ApplicationInfo GetAppInfo()
        {
            return new ApplicationInfo()
            {
                Name = "Evaluations μSerrvice",
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Version = "0.0.0"
            };
        }
    }
}
