namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using System;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Xunit;

    public class HealthServiceTests
    {
        [Fact]
        public void TestGetServiceHealth_ReturnsApplicationHealthInfo()
        {
            var expected = new ApplicationHealthInfo()
            {
                Application = new ApplicationInfo()
                {
                    Name = "Evaluations μSerrvice",
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Version = "0.0.0"
                },
                Status = ApplicationHealthStatus.Up
            };

            var service = new HealthService(new AppInfoStubDao());
            var actual = service.GetServiceHealth();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetServiceHealth_ThrowsInternalErrorServiceException()
        {
            var service = new HealthService(new AppInfoErrorStubDao());

            Assert.Throws<InternalErrorServiceException>(() => service.GetServiceHealth());
        }
    }
}
