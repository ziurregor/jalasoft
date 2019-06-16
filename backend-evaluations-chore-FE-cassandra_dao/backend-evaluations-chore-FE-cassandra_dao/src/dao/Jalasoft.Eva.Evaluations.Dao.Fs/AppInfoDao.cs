namespace Jalasoft.Eva.Evaluations.Dao.Fs
{
    using System.IO;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain;
    using Newtonsoft.Json;

    public class AppInfoDao : IAppInfoDao, IFileDaoBuilder<IAppInfoDao>
    {
        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(AppInfoDao));
        private string appInfoFile;

        public AppInfoDao()
        {
        }

        public AppInfoDao(string filename)
        {
            this.appInfoFile = filename;
        }

        public IAppInfoDao CreateFromFile(string fileName)
        {
            Log.Info(string.Format("Building DAO with {0}", fileName));
            return new AppInfoDao(fileName);
        }

        public ApplicationInfo GetAppInfo()
        {
            Log.Info(string.Format("Getting the application information from: {0}", this.appInfoFile));
            var info = default(ApplicationInfo);
            if (!File.Exists(this.appInfoFile))
            {
                var message = string.Format("The {0} file does not exist", this.appInfoFile);
                Log.Error(message);
                throw new InternalErrorDaoException(message);
            }

            var json = File.ReadAllText(this.appInfoFile);
            info = JsonConvert.DeserializeObject<ApplicationInfo>(json);

            Log.Info(string.Format("ApplicationInfo: {0}", info));
            return info;
        }
    }
}