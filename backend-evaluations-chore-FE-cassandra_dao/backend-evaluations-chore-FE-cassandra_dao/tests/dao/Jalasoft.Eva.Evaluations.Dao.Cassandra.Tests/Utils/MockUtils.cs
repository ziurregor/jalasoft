namespace Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests.Utils
{
    using global::Cassandra;
    using global::Cassandra.Mapping;
    using Moq;

    public class MockUtils
    {
        public static IConnectionFactory MockConnectionFactory(IMock<IMapper> mapperMock)
        {
            var connectionFactoryMock = new Mock<IConnectionFactory>();
            connectionFactoryMock.Setup(m => m.GetMapper(It.IsAny<ISession>())).Returns(mapperMock.Object);
            return connectionFactoryMock.Object;
        }
    }
}
