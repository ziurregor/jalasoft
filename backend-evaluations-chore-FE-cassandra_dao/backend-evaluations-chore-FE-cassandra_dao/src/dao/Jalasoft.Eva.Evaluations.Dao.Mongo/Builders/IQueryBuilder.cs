namespace Jalasoft.Eva.Evaluations.Dao.Mongo.Builders
{
    using MongoDB.Bson;

    public interface IQueryBuilder
    {
        BsonDocument BuildQuery(string property, string criteria);
    }
}
