namespace Jalasoft.Eva.Evaluations.Dao.Fs.Tests
{
    using System;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;
    using Jalasoft.Eva.Evaluations.Domain;
    using Xunit;

    public class AppInfoDaoTests
    {
        [Fact]
        public void TestGetAppInfo()
        {
            var expected = new ApplicationInfo()
            {
                Name = "Evaluations μSerrvice",
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Version = "0.0.0"
            };

            var daoBuilder = new AppInfoDao();
            var dao = daoBuilder.CreateFromFile("ApplicationInfo.json");
            var actual = dao.GetAppInfo();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetAppInfo_ThrowsInternalErrorDaoException()
        {
            var daoBuilder = new AppInfoDao();
            var dao = daoBuilder.CreateFromFile("InexistentApplicationInfo.json");
            Assert.Throws<InternalErrorDaoException>(() => dao.GetAppInfo());
        }
    }
}
