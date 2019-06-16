namespace Jalasoft.Eva.Evaluations.Dao.Mongo.Builders
{
    using MongoDB.Bson;

    public class MongoSort : IQueryBuilder
    {
        public BsonDocument BuildQuery(string property, string criteria)
        {
            return new BsonDocument
            {
                {
                    "$sort", new BsonDocument { { property, int.Parse(criteria) } }
                }
            };
        }
    }
}
