namespace Jalasoft.Eva.Evaluations.Dao.Mongo
{
    using System;
    using Jalasoft.Eva.Evaluations.Dao.Exceptions;
    using Jalasoft.Eva.Evaluations.Dao.Mongo.Builders;
    using Jalasoft.Eva.Evaluations.Domain;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public abstract class AbstractMongoDao<Y>
        where Y : class
    {
        protected string connection;
        protected string collection;

        private MongoClient client;
        private IMongoDatabase dataBase;
        private QueryBuilder queryBuilder;

        public AbstractMongoDao(string connectionString, string collection)
        {
            this.queryBuilder = new QueryBuilder();
            this.connection = connectionString;
            this.collection = collection;

            this.client = new MongoClient(connectionString);
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;

            this.dataBase = this.client
                .GetDatabase(databaseName);
        }

        protected delegate T ExecuteDelegate<T>(IMongoCollection<Y> db);

        protected delegate T ExecutePaginatedDelegate<T>(IMongoCollection<Y> db, int totalLength);

        protected T ExecutePaginatedQuery<T>(ExecutePaginatedDelegate<T> del, QueryParameters queryParams)
        {
            var viewName = $"{this.collection}.{Guid.NewGuid()}";
            try
            {
                var pipeline = this.queryBuilder.BuildPipeline(queryParams);
                this.dataBase.CreateView(viewName, this.collection, pipeline);
                var mongoCollection = this.dataBase.GetCollection<Y>(viewName);
                var totalLength = mongoCollection.CountDocuments(new BsonDocument());
                return del.Invoke(mongoCollection, (int)totalLength);
            }
            catch (Exception ex)
            {
                throw this.ProcessException(ex);
            }
            finally
            {
                this.dataBase.DropCollection(viewName);
            }
        }

        protected T ExecuteQuery<T>(ExecuteDelegate<T> del)
        {
            try
            {
                var mongoCollection = this.dataBase.GetCollection<Y>(this.collection);
                return del.Invoke(mongoCollection);
            }
            catch (Exception ex)
            {
                throw this.ProcessException(ex);
            }
        }

        private Exception ProcessException(Exception ex)
        {
            if (ex is DaoException)
            {
                return (DaoException)ex;
            }

            return new InternalErrorDaoException("There is a problem with the DAO operation", ex);
        }
    }
}
